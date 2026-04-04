/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     5/16/2025 11:45:25 PM                        */
/*==============================================================*/

CREATE DATABASE SS;

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADDRESS') and o.name = 'FK_ADDRESS_RESIDES_INSURANC')
alter table ADDRESS
   drop constraint FK_ADDRESS_RESIDES_INSURANC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CAR') and o.name = 'FK_CAR_COVERS_INSURANC')
alter table CAR
   drop constraint FK_CAR_COVERS_INSURANC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CAR_ACCIDENT') and o.name = 'FK_CAR_ACCI_INVOLVES_CAR')
alter table CAR_ACCIDENT
   drop constraint FK_CAR_ACCI_INVOLVES_CAR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CAR_ACCIDENT') and o.name = 'FK_CAR_ACCI_RELATIONS_MONTHLY_')
alter table CAR_ACCIDENT
   drop constraint FK_CAR_ACCI_RELATIONS_MONTHLY_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COLOR') and o.name = 'FK_COLOR_HAS_CAR')
alter table COLOR
   drop constraint FK_COLOR_HAS_CAR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMITS') and o.name = 'FK_COMMITS_COMMITS_CUSTOMER')
alter table COMMITS
   drop constraint FK_COMMITS_COMMITS_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMITS') and o.name = 'FK_COMMITS_COMMITS2_CAR_ACCI')
alter table COMMITS
   drop constraint FK_COMMITS_COMMITS2_CAR_ACCI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPLOYEE') and o.name = 'FK_EMPLOYEE_RELATINSH_EMPLOYEE')
alter table EMPLOYEE
   drop constraint FK_EMPLOYEE_RELATINSH_EMPLOYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INSURANCE_POLICY') and o.name = 'FK_INSURANC_HASSSSS_CUSTOMER')
alter table INSURANCE_POLICY
   drop constraint FK_INSURANC_HASSSSS_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INSURANCE_POLICY') and o.name = 'FK_INSURANC_PROVIDES_INSURANC')
alter table INSURANCE_POLICY
   drop constraint FK_INSURANC_PROVIDES_INSURANC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MONTHLY_REPORT') and o.name = 'FK_MONTHLY__WRITES_EMPLOYEE')
alter table MONTHLY_REPORT
   drop constraint FK_MONTHLY__WRITES_EMPLOYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OWNSS') and o.name = 'FK_OWNSS_OWNSS_CUSTOMER')
alter table OWNSS
   drop constraint FK_OWNSS_OWNSS_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OWNSS') and o.name = 'FK_OWNSS_OWNSS2_CAR')
alter table OWNSS
   drop constraint FK_OWNSS_OWNSS2_CAR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHONE_NUMBER') and o.name = 'FK_PHONE_NU_ACQUIRES_EMPLOYEE')
alter table PHONE_NUMBER
   drop constraint FK_PHONE_NU_ACQUIRES_EMPLOYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHONE_NUMBER2') and o.name = 'FK_PHONE_NU_OWNS_CUSTOMER')
alter table PHONE_NUMBER2
   drop constraint FK_PHONE_NU_OWNS_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHONE_NUMBER3') and o.name = 'FK_PHONE_NU_HOLDS_INSURANC')
alter table PHONE_NUMBER3
   drop constraint FK_PHONE_NU_HOLDS_INSURANC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('POLICYCOVERAGEITEM') and o.name = 'FK_POLICYCO_INCLUDES_INSURANC')
alter table POLICYCOVERAGEITEM
   drop constraint FK_POLICYCO_INCLUDES_INSURANC
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ADDRESS')
            and   name  = 'RESIDES_FK'
            and   indid > 0
            and   indid < 255)
   drop index ADDRESS.RESIDES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADDRESS')
            and   type = 'U')
   drop table ADDRESS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CAR')
            and   name  = 'COVERS_FK'
            and   indid > 0
            and   indid < 255)
   drop index CAR.COVERS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CAR')
            and   type = 'U')
   drop table CAR
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CAR_ACCIDENT')
            and   name  = 'RELATIONSHIP_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index CAR_ACCIDENT.RELATIONSHIP_3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CAR_ACCIDENT')
            and   name  = 'INVOLVES_FK'
            and   indid > 0
            and   indid < 255)
   drop index CAR_ACCIDENT.INVOLVES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CAR_ACCIDENT')
            and   type = 'U')
   drop table CAR_ACCIDENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COLOR')
            and   name  = 'HAS_FK'
            and   indid > 0
            and   indid < 255)
   drop index COLOR.HAS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('COLOR')
            and   type = 'U')
   drop table COLOR
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COMMITS')
            and   name  = 'COMMITS2_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMMITS.COMMITS2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COMMITS')
            and   name  = 'COMMITS_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMMITS.COMMITS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('COMMITS')
            and   type = 'U')
   drop table COMMITS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CUSTOMER')
            and   type = 'U')
   drop table CUSTOMER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLOYEE')
            and   name  = 'RELATINSHIP_6_FK'
            and   indid > 0
            and   indid < 255)
   drop index EMPLOYEE.RELATINSHIP_6_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPLOYEE')
            and   type = 'U')
   drop table EMPLOYEE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INSURANCEPROVIDER')
            and   type = 'U')
   drop table INSURANCEPROVIDER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('INSURANCE_POLICY')
            and   name  = 'PROVIDES_FK'
            and   indid > 0
            and   indid < 255)
   drop index INSURANCE_POLICY.PROVIDES_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('INSURANCE_POLICY')
            and   name  = 'HASSSSS_FK'
            and   indid > 0
            and   indid < 255)
   drop index INSURANCE_POLICY.HASSSSS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INSURANCE_POLICY')
            and   type = 'U')
   drop table INSURANCE_POLICY
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MONTHLY_REPORT')
            and   name  = 'WRITES_FK'
            and   indid > 0
            and   indid < 255)
   drop index MONTHLY_REPORT.WRITES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MONTHLY_REPORT')
            and   type = 'U')
   drop table MONTHLY_REPORT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('OWNSS')
            and   name  = 'OWNSS2_FK'
            and   indid > 0
            and   indid < 255)
   drop index OWNSS.OWNSS2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('OWNSS')
            and   name  = 'OWNSS_FK'
            and   indid > 0
            and   indid < 255)
   drop index OWNSS.OWNSS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OWNSS')
            and   type = 'U')
   drop table OWNSS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHONE_NUMBER')
            and   name  = 'ACQUIRES_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHONE_NUMBER.ACQUIRES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHONE_NUMBER')
            and   type = 'U')
   drop table PHONE_NUMBER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHONE_NUMBER2')
            and   name  = 'OWNS_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHONE_NUMBER2.OWNS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHONE_NUMBER2')
            and   type = 'U')
   drop table PHONE_NUMBER2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHONE_NUMBER3')
            and   name  = 'HOLDS_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHONE_NUMBER3.HOLDS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHONE_NUMBER3')
            and   type = 'U')
   drop table PHONE_NUMBER3
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('POLICYCOVERAGEITEM')
            and   name  = 'INCLUDES_FK'
            and   indid > 0
            and   indid < 255)
   drop index POLICYCOVERAGEITEM.INCLUDES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('POLICYCOVERAGEITEM')
            and   type = 'U')
   drop table POLICYCOVERAGEITEM
go

/*==============================================================*/
/* Table: ADDRESS                                               */
/*==============================================================*/
create table ADDRESS (
   ADDDDDD              varchar(100)         not null,
   PROVIDERIFD          int                  not null,
   PROVIDERID           int                  not null,
   constraint PK_ADDRESS primary key nonclustered (ADDDDDD, PROVIDERIFD)
)
go

/*==============================================================*/
/* Index: RESIDES_FK                                            */
/*==============================================================*/
create index RESIDES_FK on ADDRESS (
PROVIDERID ASC
)
go

/*==============================================================*/
/* Table: CAR                                                   */
/*==============================================================*/
create table CAR (
   CARID                int                  not null,
   POLICYID             int                  not null,
   MODEL                varchar(20)          null,
   MANIFACTURER         varchar(30)          null,
   YEAR                 int                  null,
   LICENSE_PLATE        varchar(10)          null,
   constraint PK_CAR primary key nonclustered (CARID)
)
go

/*==============================================================*/
/* Index: COVERS_FK                                             */
/*==============================================================*/
create index COVERS_FK on CAR (
POLICYID ASC
)
go

/*==============================================================*/
/* Table: CAR_ACCIDENT                                          */
/*==============================================================*/
create table CAR_ACCIDENT (
   SEVERITY             int                  null,
   MONTH                int                  null,
   YEAR                 int                  null,
   ACCIDENT_ID          int                  not null,
   REPORTID             int                  not null,
   CARID                int                  not null,
   CITY                 varchar(25)          null,
   STATE                varchar(25)          null,
   STREET               varchar(25)          null,
   constraint PK_CAR_ACCIDENT primary key nonclustered (ACCIDENT_ID)
)
go

/*==============================================================*/
/* Index: INVOLVES_FK                                           */
/*==============================================================*/
create index INVOLVES_FK on CAR_ACCIDENT (
CARID ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_3_FK on CAR_ACCIDENT (
REPORTID ASC
)
go

/*==============================================================*/
/* Table: COLOR                                                 */
/*==============================================================*/
create table COLOR (
   COLOR                varchar(15)          not null,
   CARID                int                  null,
   constraint PK_COLOR primary key nonclustered (COLOR)
)
go

/*==============================================================*/
/* Index: HAS_FK                                                */
/*==============================================================*/
create index HAS_FK on COLOR (
CARID ASC
)
go

/*==============================================================*/
/* Table: COMMITS                                               */
/*==============================================================*/
create table COMMITS (
   CUSTOMERID           int                  not null,
   ACCIDENT_ID          int                  not null,
   constraint PK_COMMITS primary key (CUSTOMERID, ACCIDENT_ID)
)
go

/*==============================================================*/
/* Index: COMMITS_FK                                            */
/*==============================================================*/
create index COMMITS_FK on COMMITS (
CUSTOMERID ASC
)
go

/*==============================================================*/
/* Index: COMMITS2_FK                                           */
/*==============================================================*/
create index COMMITS2_FK on COMMITS (
ACCIDENT_ID ASC
)
go

/*==============================================================*/
/* Table: CUSTOMER                                              */
/*==============================================================*/
create table CUSTOMER (
   CUSTOMERID           int                  not null,
   FIRSTNAME            varchar(20)          not null,
   LASTNAME             varchar(20)          not null,
   EMAIL                varchar(40)          not null,
   CITY                 varchar(25)          not null,
   STATE                varchar(25)          not null,
   STREET               varchar(25)          not null,
   DRIVERLICENSENO      int                  not null,
   constraint PK_CUSTOMER primary key nonclustered (CUSTOMERID)
)
go

/*==============================================================*/
/* Table: EMPLOYEE                                              */
/*==============================================================*/
create table EMPLOYEE (
   EMPLOYEEID           int                  not null,
   EMP_EMPLOYEEID       int                  null,
   FIRST_NAME           varchar(20)          null,
   LAST_NAME            varchar(20)          null,
   EMAIL                varchar(40)          null,
   SALARY               int                  null,
   constraint PK_EMPLOYEE primary key nonclustered (EMPLOYEEID)
)
go

/*==============================================================*/
/* Index: RELATINSHIP_6_FK                                      */
/*==============================================================*/
create index RELATINSHIP_6_FK on EMPLOYEE (
EMP_EMPLOYEEID ASC
)
go

/*==============================================================*/
/* Table: INSURANCEPROVIDER                                     */
/*==============================================================*/
create table INSURANCEPROVIDER (
   PROVIDERID           int                  not null,
   PROVIDERNAME         varchar(40)          not null,
   constraint PK_INSURANCEPROVIDER primary key nonclustered (PROVIDERID)
)
go

/*==============================================================*/
/* Table: INSURANCE_POLICY                                      */
/*==============================================================*/
create table INSURANCE_POLICY (
   POLICYID             int                  not null,
   CUSTOMERID           int                  not null,
   PROVIDERID           int                  not null,
   "PLAN"               varchar(20)          not null,
   STARTDATE            datetime             not null,
   ENDDATE              datetime             not null,
   POLICYNUMBER         int                  not null,
   constraint PK_INSURANCE_POLICY primary key nonclustered (POLICYID)
)
go

/*==============================================================*/
/* Index: HASSSSS_FK                                            */
/*==============================================================*/
create index HASSSSS_FK on INSURANCE_POLICY (
CUSTOMERID ASC
)
go

/*==============================================================*/
/* Index: PROVIDES_FK                                           */
/*==============================================================*/
create index PROVIDES_FK on INSURANCE_POLICY (
PROVIDERID ASC
)
go

/*==============================================================*/
/* Table: MONTHLY_REPORT                                        */
/*==============================================================*/
create table MONTHLY_REPORT (
   REPORTID             int                  not null,
   EMPLOYEEID           int                  not null,
   MONTH                int                  null,
   YEAR                 int                  null,
   TOTALACCIDENTS       int                  null,
   constraint PK_MONTHLY_REPORT primary key nonclustered (REPORTID)
)
go

/*==============================================================*/
/* Index: WRITES_FK                                             */
/*==============================================================*/
create index WRITES_FK on MONTHLY_REPORT (
EMPLOYEEID ASC
)
go

/*==============================================================*/
/* Table: OWNSS                                                 */
/*==============================================================*/
create table OWNSS (
   CUSTOMERID           int                  not null,
   CARID                int                  not null,
   constraint PK_OWNSS primary key (CUSTOMERID, CARID)
)
go

/*==============================================================*/
/* Index: OWNSS_FK                                              */
/*==============================================================*/
create index OWNSS_FK on OWNSS (
CUSTOMERID ASC
)
go

/*==============================================================*/
/* Index: OWNSS2_FK                                             */
/*==============================================================*/
create index OWNSS2_FK on OWNSS (
CARID ASC
)
go

/*==============================================================*/
/* Table: PHONE_NUMBER                                          */
/*==============================================================*/
create table PHONE_NUMBER (
   PHONE_NUMBER         varchar(11)          not null,
   EMPID                int                  not null,
   EMPLOYEEID           int                  not null,
   constraint PK_PHONE_NUMBER primary key nonclustered (PHONE_NUMBER, EMPID)
)
go

/*==============================================================*/
/* Index: ACQUIRES_FK                                           */
/*==============================================================*/
create index ACQUIRES_FK on PHONE_NUMBER (
EMPLOYEEID ASC
)
go

/*==============================================================*/
/* Table: PHONE_NUMBER2                                         */
/*==============================================================*/
create table PHONE_NUMBER2 (
   PHONE_NUMBER2        varchar(11)          not null,
   CUSTID               int                  not null,
   CUSTOMERID           int                  not null,
   constraint PK_PHONE_NUMBER2 primary key nonclustered (PHONE_NUMBER2, CUSTID)
)
go

/*==============================================================*/
/* Index: OWNS_FK                                               */
/*==============================================================*/
create index OWNS_FK on PHONE_NUMBER2 (
CUSTOMERID ASC
)
go

/*==============================================================*/
/* Table: PHONE_NUMBER3                                         */
/*==============================================================*/
create table PHONE_NUMBER3 (
   PHONE_NUMBER3        varchar(11)          not null,
   PROVIDERID           int                  not null,
   constraint PK_PHONE_NUMBER3 primary key nonclustered (PHONE_NUMBER3)
)
go

/*==============================================================*/
/* Index: HOLDS_FK                                              */
/*==============================================================*/
create index HOLDS_FK on PHONE_NUMBER3 (
PROVIDERID ASC
)
go

/*==============================================================*/
/* Table: POLICYCOVERAGEITEM                                    */
/*==============================================================*/
create table POLICYCOVERAGEITEM (
   POLICYID             int                  not null,
   COVERAGEAMOUNT       varchar(40)          not null,
   COVERAGETYPE         varchar(40)          not null
)
go

/*==============================================================*/
/* Index: INCLUDES_FK                                           */
/*==============================================================*/
create index INCLUDES_FK on POLICYCOVERAGEITEM (
POLICYID ASC
)
go

alter table ADDRESS
   add constraint FK_ADDRESS_RESIDES_INSURANC foreign key (PROVIDERID)
      references INSURANCEPROVIDER (PROVIDERID)
go

alter table CAR
   add constraint FK_CAR_COVERS_INSURANC foreign key (POLICYID)
      references INSURANCE_POLICY (POLICYID)
go

alter table CAR_ACCIDENT
   add constraint FK_CAR_ACCI_INVOLVES_CAR foreign key (CARID)
      references CAR (CARID)
go

alter table CAR_ACCIDENT
   add constraint FK_CAR_ACCI_RELATIONS_MONTHLY_ foreign key (REPORTID)
      references MONTHLY_REPORT (REPORTID)
go

alter table COLOR
   add constraint FK_COLOR_HAS_CAR foreign key (CARID)
      references CAR (CARID)
go

alter table COMMITS
   add constraint FK_COMMITS_COMMITS_CUSTOMER foreign key (CUSTOMERID)
      references CUSTOMER (CUSTOMERID)
go

alter table COMMITS
   add constraint FK_COMMITS_COMMITS2_CAR_ACCI foreign key (ACCIDENT_ID)
      references CAR_ACCIDENT (ACCIDENT_ID)
go

alter table EMPLOYEE
   add constraint FK_EMPLOYEE_RELATINSH_EMPLOYEE foreign key (EMP_EMPLOYEEID)
      references EMPLOYEE (EMPLOYEEID)
go

alter table INSURANCE_POLICY
   add constraint FK_INSURANC_HASSSSS_CUSTOMER foreign key (CUSTOMERID)
      references CUSTOMER (CUSTOMERID)
go

alter table INSURANCE_POLICY
   add constraint FK_INSURANC_PROVIDES_INSURANC foreign key (PROVIDERID)
      references INSURANCEPROVIDER (PROVIDERID)
go

alter table MONTHLY_REPORT
   add constraint FK_MONTHLY__WRITES_EMPLOYEE foreign key (EMPLOYEEID)
      references EMPLOYEE (EMPLOYEEID)
go

alter table OWNSS
   add constraint FK_OWNSS_OWNSS_CUSTOMER foreign key (CUSTOMERID)
      references CUSTOMER (CUSTOMERID)
go

alter table OWNSS
   add constraint FK_OWNSS_OWNSS2_CAR foreign key (CARID)
      references CAR (CARID)
go

alter table PHONE_NUMBER
   add constraint FK_PHONE_NU_ACQUIRES_EMPLOYEE foreign key (EMPLOYEEID)
      references EMPLOYEE (EMPLOYEEID)
go

alter table PHONE_NUMBER2
   add constraint FK_PHONE_NU_OWNS_CUSTOMER foreign key (CUSTOMERID)
      references CUSTOMER (CUSTOMERID)
go

alter table PHONE_NUMBER3
   add constraint FK_PHONE_NU_HOLDS_INSURANC foreign key (PROVIDERID)
      references INSURANCEPROVIDER (PROVIDERID)
go

alter table POLICYCOVERAGEITEM
   add constraint FK_POLICYCO_INCLUDES_INSURANC foreign key (POLICYID)
      references INSURANCE_POLICY (POLICYID)
go

