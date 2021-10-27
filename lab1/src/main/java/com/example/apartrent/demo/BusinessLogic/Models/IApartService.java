package com.example.apartrent.demo.BusinessLogic.Models;

import com.example.apartrent.demo.DataAccess.Entity.ApartmentEntity;

import java.util.List;

public interface IApartService {
    void save(ApartmentEntity apartment);
    List<ApartmentEntity> getAllApart();
    ApartmentEntity getApartById(int id);
    void delete(int id);
    List<ApartmentEntity> filterApart( String region, Integer maxPr, Integer minPr, String roomCount);
}
