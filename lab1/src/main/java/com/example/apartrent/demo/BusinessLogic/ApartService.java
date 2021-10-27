package com.example.apartrent.demo.BusinessLogic;

import com.example.apartrent.demo.BusinessLogic.Models.IApartService;
import com.example.apartrent.demo.DataAccess.Entity.ApartmentEntity;
import com.example.apartrent.demo.DataAccess.Repository.ApartmentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.RequestParam;

import java.util.List;

@Service
public class ApartService implements IApartService {
    @Autowired
    ApartmentRepository apartmentRepository;

    @Override
    public void save(ApartmentEntity apartment){
        apartmentRepository.save(apartment);
    }
    @Override
    public List<ApartmentEntity> getAllApart(){
         return apartmentRepository.findAll();
    }

    @Override
    public ApartmentEntity getApartById(int id){
         return apartmentRepository.findById(id).get();
    }

    @Override
    public void delete(int id){
         apartmentRepository.delete(getApartById(id));
    }

    @Override
    public List<ApartmentEntity> filterApart( String region, Integer maxPr, Integer minPr, String roomCount){
        String reg="";
        Integer count = null;
        if(region!=null) {
            reg = region.equals("") ? null : region;
        }
        else reg=null;
        if(roomCount != null){
            count = Integer.parseInt(roomCount);
        }
        System.out.println("min "+ minPr);
        System.out.println("max "+ maxPr);
        return apartmentRepository.getFilteredJApart(reg, minPr, maxPr, count);
    }

}
