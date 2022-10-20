create database userdb;
use userdb;

create table serviceuser
( 
    Id int auto_increment,
    UiD TEXT(255),
    CommunicationType TEXT(255),
    IntensityReal TEXT(255),
    IntensityWish TEXT(255),
    Control TEXT(255),
constraint serviceuser_pk
		primary key (Id) 
);
