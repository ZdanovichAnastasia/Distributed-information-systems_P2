package com.example.apartrent.demo.Controller;

import com.example.apartrent.demo.BusinessLogic.Models.IApartService;
import com.example.apartrent.demo.BusinessLogic.Models.IFileService;
import com.example.apartrent.demo.DataAccess.Entity.ApartmentEntity;
import com.example.apartrent.demo.DataAccess.Repository.ApartmentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.io.InputStreamResource;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import javax.validation.Valid;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;

@Controller
public class ApartmentController {
    @Autowired
    IApartService apartService;
    //ApartmentRepository apartmentRepository;
    @Autowired
    IFileService fileService;

    @GetMapping({"/showApart"})
    public String showApart(Model model, @RequestParam String idApart){
        if(idApart != null){
            ApartmentEntity apartmentEntity = apartService.getApartById(Integer.parseInt(idApart));
            //ApartmentEntity apartmentEntity = apartmentRepository.findById(Integer.parseInt(idApart)).get();
            model.addAttribute("apartInfo", apartmentEntity);
            apartmentEntity.setViewNum(apartmentEntity.getViewNum()+1);
            //apartmentRepository.save(apartmentEntity);
            apartService.save(apartmentEntity);
        }
        else model.addAttribute("apartInfo", null);
        return "showApart";
    }

    @GetMapping("/addApart")
    public String showForm(@ModelAttribute("apart") ApartmentEntity apartment, Model model){
        fillRegions(model);
        return "addApart";
    }

    @PostMapping("/newApart")
    public String addApart(@ModelAttribute("apart")@Valid ApartmentEntity apartment, BindingResult bindingResult, Model model){
        if(bindingResult.hasErrors()){
            fillRegions(model);
            return "addApart";
        }
        //apartmentRepository.save(apartment);
        apartService.save(apartment);
        model.addAttribute("apartList", apartService.getAllApart());
        return "showAllApart";
    }

    @GetMapping("apart/{id}/edit")
    public String editApart(Model model, @PathVariable("id") int id) {
        //model.addAttribute("streams", businessStreamServiceRest.getAllBusinessStreams());
        //model.addAttribute("company", companyServiceRest.getCompanyById(id));
        model.addAttribute("apart", apartService.getApartById(id));
        fillRegions(model);
        return "editApart";
    }

    @PostMapping("apart/{id}")
    public String update(@ModelAttribute("apart") @Valid ApartmentEntity apartment, BindingResult bindingResult,
                         @PathVariable("id") int id, Model model) {
        if (bindingResult.hasErrors()) {
            fillRegions(model);
            return "editApart";
        }
        apartment.setId(id);
        //apartmentRepository.save(apartment);
        apartService.save(apartment);
        fillRegions(model);
        model.addAttribute("apartList",  apartService.getAllApart());
        return "showAllApart";
    }

    @PostMapping("deleteApart")
    public String deleteApart(Model model, @RequestParam String id){
        //ApartmentEntity apartmentEntity = apartService.getApartById(Integer.parseInt(id));
        //System.out.println("id "+ apartmentEntity.getId());
        //apartmentRepository.delete(apartmentEntity);
        apartService.delete(Integer.parseInt(id));
        fillRegions(model);
        model.addAttribute("apartList",  apartService.getAllApart());
        return "showAllApart";
    }

    @GetMapping({"/"})
    public String showAllJobPosts(Model model) {
        fillRegions(model);
        model.addAttribute("apartList",  apartService.getAllApart());
        return "showAllApart";
    }

    @PostMapping("filterApart")
    public String filter(Model model, @RequestParam(required=false) String region, @RequestParam(required=false) Integer maxPr,
                         @RequestParam(required=false) Integer minPr, @RequestParam(required=false) String roomCount){
        fillRegions(model);
        /*String reg="";
        Integer count = null;
        if(region!=null) {
            reg = region.equals("") ? null : region;
        }
        else reg=null;
        if(roomCount != null){
            count = Integer.parseInt(roomCount);
        }
        model.addAttribute("apartList", apartmentRepository.getFilteredJApart(reg, minPr, maxPr, count));*/
        model.addAttribute("apartList", apartService.filterApart(region, maxPr, minPr, roomCount));
        return "showAllApart";
    }

    @GetMapping("/apartment/download")
    public ResponseEntity<InputStreamResource> saveToTXTApartment(@RequestParam String idApart, RedirectAttributes attributes) throws FileNotFoundException {
        String fileName = "apartment№"+idApart+".txt";
        ApartmentEntity apartment = apartService.getApartById(Integer.parseInt(idApart));
        String fileContent =
                "Region: "+apartment.getRegion()+"\n"+
                        "Street: "+apartment.getStreet()+"\n"+
                        "House number: "+apartment.getHouse()+"\n"+
                        "Count of room: "+apartment.getRoomCount()+"\n"+
                        "Price: "+apartment.getPrice()+"\n"+
                        "Description: "+apartment.getDescription()+"\n"+
                        "Owner name: "+apartment.getName()+"\n"+
                        "Email: "+apartment.getEmail()+"\n"+
                        "Phone: "+apartment.getPhone();

        // Create text file
        Path exportedPath = fileService.export(fileContent, fileName);

        // Download file with InputStreamResource
        File exportedFile = exportedPath.toFile();
        FileInputStream fileInputStream = new FileInputStream(exportedFile);
        InputStreamResource inputStreamResource = new InputStreamResource(fileInputStream);

        return ResponseEntity.ok()
                .header(HttpHeaders.CONTENT_DISPOSITION, "attachment;filename=" + fileName)
                .contentType(MediaType.TEXT_PLAIN)
                .contentLength(exportedFile.length())
                .body(inputStreamResource);
    }

    private void fillRegions(Model model){
        List<String> regions = new ArrayList<>();
        regions.add("Минский");
        regions.add("Брестский");
        regions.add("Гомельский");
        regions.add("Гродненский");
        regions.add("Могилевский");
        regions.add("Витебский");
        model.addAttribute("regions", regions);
    }
}
