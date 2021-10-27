package com.example.apartrent.demo.BusinessLogic.Models;

import java.nio.file.Path;

public interface IFileService {
    Path export(String fileContent, String fileName);
}
