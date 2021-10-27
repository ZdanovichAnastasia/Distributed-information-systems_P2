package com.example.apartrent.demo.DataAccess.Entity;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.ToString;

import javax.persistence.*;
import javax.validation.constraints.*;

@Entity
@Table(name = "apartment")
public class ApartmentEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idapartment")
    private int id;

    @Column(name = "square")
    @Max(value = 300, message = "Значение не может быть больше 300")
    @Min(value = 0, message = "Значение не может быть отрицательным")
    private Integer square;

    @Column(name = "room_count")
    private Integer roomCount;

    @Column(name = "description")
    @Size(max = 10000)
    private String description;

    @Column(name = "price")
    @Max(value = 2000, message = "Значение не может быть больше 2000")
    @Min(value = 0, message = "Значение не может быть отрицательным")
    private Integer price;

    @Column(name = "view_num")
    private int viewNum;

    @Column(name = "region")
    private String region;

    @Column(name = "street")
    private String street;

    @Column(name = "house")
    private Integer house;

    @Column(name = "name")
    private String name;

    @Column(name = "phone")
    @Pattern(regexp = "^(\\+\\d{2,3})\\(\\d{2,3}\\)\\d{7,8}$", message = "Поле должно быть заполнено в формате +__(___)_______")
    private String phone;

    @Column(name = "email")
    @Email
    private String email;

    public ApartmentEntity(){}


    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Integer getSquare() {
        return square;
    }

    public void setSquare(Integer square) {
        this.square = square;
    }

    public Integer getRoomCount() {
        return roomCount;
    }

    public void setRoomCount(Integer roomCount) {
        this.roomCount = roomCount;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Integer getPrice() {
        return price;
    }

    public void setPrice(Integer price) {
        this.price = price;
    }

    public int getViewNum() {
        return viewNum;
    }

    public void setViewNum(int viewNum) {
        this.viewNum = viewNum;
    }

    public String getRegion() {
        return region;
    }

    public void setRegion(String region) {
        this.region = region;
    }

    public String getStreet() {
        return street;
    }

    public void setStreet(String street) {
        this.street = street;
    }

    public Integer getHouse() {
        return house;
    }

    public void setHouse(Integer house) {
        this.house = house;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
