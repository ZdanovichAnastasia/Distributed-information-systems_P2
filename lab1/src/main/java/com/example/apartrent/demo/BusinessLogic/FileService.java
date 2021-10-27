package com.example.apartrent.demo.BusinessLogic;

import com.example.apartrent.demo.BusinessLogic.Models.IFileService;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;

@Service
public class FileService implements IFileService {
    private static final String EXPORT_DIRECTORY = "D:\\";
    @Override
    public Path export(String fileContent, String fileName) {
        Path filePath = Paths.get(EXPORT_DIRECTORY, fileName);

        Path exportedFilePath = null;
        try {
            exportedFilePath = Files.write(filePath, fileContent.getBytes(), StandardOpenOption.CREATE);
            return exportedFilePath;
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }
}
