package com.example.apartrent.demo.DataAccess.Repository;

import com.example.apartrent.demo.DataAccess.Entity.ApartmentEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ApartmentRepository extends JpaRepository<ApartmentEntity,Integer> {
    @Query("select b from ApartmentEntity b where (:minPr is null  OR b.price>=:minPr) AND (:maxPr is null  OR b.price<=:maxPr )" +
            "AND (:roomCount is null  OR b.roomCount=:roomCount ) AND (:region is null  OR b.region=:region )")
    List<ApartmentEntity> getFilteredJApart(String region, Integer minPr, Integer maxPr, Integer roomCount);
}
