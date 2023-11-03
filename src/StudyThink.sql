CREATE TABLE "Students"(
    "Id" BIGINT PRIMARY KEY IDENTITY(1,1),
    "FirstName" nchar(255),
    "LastName" nchar(255) NULL,
    "DateOfBirth" DATE NULL,
    "UserName" nchar(255) UNIQUE,
    "Password" nchar(255),
    "Email" nchar(255) UNIQUE,
    "PhoneNumber" nchar(255) UNIQUE ,
    "Gender" TEXT  ,
    "CreatedAt" DATE  DEFAULT GETDATE(),
    "UpdatedAt" DATE  ,
    "DeletedAt" DATE  ,
    "ImagePath" TEXT  
);

CREATE TABLE "Categories"(
    "Id" BIGINT  PRIMARY KEY IDENTITY(1,1),
    "Name" TEXT  ,
    "Description" TEXT  
);

CREATE TABLE "Admins"(
    "Id" BIGINT  PRIMARY KEY IDENTITY(1,1),
    "FirstName" nchar(255),
    "LastName" nchar(255),
    "PhoneNumber" nchar(255) UNIQUE,
    "Email" nchar(255) UNIQUE ,
    "Password" nchar(255),
    "CreatedAt" DATE DEFAULT GETDATE() ,
    "UpdatedAt" DATE  ,
    "DeletedAt" DATE  ,
    "Role" TEXT  
);

CREATE TABLE "Callaborators"(
    "Id" BIGINT  PRIMARY KEY IDENTITY(1,1),
    "Name" TEXT,
    "ImagePath" TEXT  ,
    "Description" TEXT  ,
    "Email" NVARCHAR(255) UNIQUE ,
    "PhoneNumber" NVARCHAR(255) UNIQUE  
);


CREATE TABLE "Payment"(
    "Id" BIGINT PRIMARY KEY IDENTITY(1,1), 
    "Type" TEXT  ,
    "Status" TEXT  ,
    "Description" TEXT  ,
    "CourseId" BIGINT  
);


CREATE TABLE "CourseRequirments"(
    "Id" BIGINT PRIMARY KEY IDENTITY(1,1),
    "Requirments" TEXT ,
    "CourseId" BIGINT  ,
    "CreatedAt" DATE DEFAULT GETDATE() ,
    "UpdatedAt" DATE 
);

CREATE TABLE "TeacherCourses"(
    "Id" BIGINT PRIMARY KEY IDENTITY(1,1),
    "TeacherId" BIGINT,
    "CourseId" BIGINT 
);

GO

CREATE TABLE "Teachers"(
    "Id" BIGINT IDENTITY(1, 1) PRIMARY KEY,
    "FirstName" nchar(255),
    "LastName" nchar(255),
    "DataOfBirth" DATE,
    "ImagePath" TEXT,
    "Level" TEXT,
    "Description" TEXT,
    "Gender" TEXT,
    "CreatedAt" DATE DEFAULT GETDATE(),
    "UpdatedAt" DATE,
    "DeletedAt" DATE  ,
    "Email" nchar(255) UNIQUE,
    "PhoneNumber" nchar(255) UNIQUE,
    "Password" nchar(255)
);


CREATE TABLE "CourseModuls"(
    "Id" BIGINT IDENTITY(1,1) PRIMARY KEY,
    "Name" TEXT  ,
    "CourseId" BIGINT  ,
    "CreatedAt" DATE DEFAULT GETDATE()  ,
    "UpdatedAt" DATE  
);

CREATE TABLE "CourseComments"(
    "Id" BIGINT  IDENTITY (1,1) PRIMARY KEY,
    "Comment" TEXT  ,
    "StudentId" BIGINT  ,
    "CourseId" BIGINT  ,
    "CreatedAt" DATE DEFAULT GETDATE(),
    "UpdatedAt" DATE  ,
    "AdminId" BIGINT  
);

CREATE TABLE "Courses"(
    "Id" BIGINT IDENTITY(1,1) PRIMARY KEY,
    "Name" TEXT  ,
    "Description" TEXT  ,
    "CategoryId" BIGINT  ,
    "Price" FLOAT  ,
    "ImagePath" TEXT  ,
    "TotalPrice" FLOAT,
    "Lessons" BIGINT  ,
    "Duration" FLOAT  ,
    "Language" TEXT  ,
    "DiscountPrice" FLOAT,
    "CreatedAt" DATE DEFAULT GETDATE(),
    "UpdatedAt" DATE,
    "CourseReqId" BIGINT  
);

CREATE TABLE "PaymentDetails"(
    "CardHolderName" TEXT  ,
    "CardNumber" TEXT  ,
    "ExpirationDate" TEXT  ,
    "CardCodeCVV" TEXT,
    "CardPhoneNumber" TEXT,
    "StudentId" BIGINT  ,
    "CreatedAt" DATE DEFAULT GETDATE(),
    "IsPaid" TEXT  ,
    "CourseId" BIGINT,
    PRIMARY KEY ("StudentId", "CourseId")
);

CREATE TABLE "Videos"(
    "Id" BIGINT IDENTITY(1,1) PRIMARY KEY,
    "Name" TEXT ,
    "VideoPath" TEXT  ,
    "Length" FLOAT,
    "CourseModulsId" BIGINT,
    "CreatedAt" DATE DEFAULT GETDATE(),
    "UpdatedAt" DATE,
    "AdminId" BIGINT  
);


GO
ALTER TABLE
    "PaymentDetails" ADD CONSTRAINT "paymentdetails_courseid_foreign" FOREIGN KEY("CourseId") REFERENCES "Courses"("Id");
ALTER TABLE
    "CourseModuls" ADD CONSTRAINT "coursemoduls_courseid_foreign" FOREIGN KEY("CourseId") REFERENCES "Courses"("Id");
ALTER TABLE
    "Courses" ADD CONSTRAINT "courses_coursereqid_foreign" FOREIGN KEY("CourseReqId") REFERENCES "CourseRequirments"("Id");
ALTER TABLE
    "TeacherCourses" ADD CONSTRAINT "teachercourses_courseid_foreign" FOREIGN KEY("CourseId") REFERENCES "Courses"("Id");
ALTER TABLE
    "CourseRequirments" ADD CONSTRAINT "courserequirments_courseid_foreign" FOREIGN KEY("CourseId") REFERENCES "Courses"("Id");
ALTER TABLE
    "Videos" ADD CONSTRAINT "videos_adminid_foreign" FOREIGN KEY("AdminId") REFERENCES "Admins"("Id");
ALTER TABLE
    "CourseComments" ADD CONSTRAINT "coursecomments_courseid_foreign" FOREIGN KEY("CourseId") REFERENCES "Courses"("Id");
ALTER TABLE
    "TeacherCourses" ADD CONSTRAINT "teachercourses_teacherid_foreign" FOREIGN KEY("TeacherId") REFERENCES "Teachers"("Id");
ALTER TABLE
    "CourseComments" ADD CONSTRAINT "coursecomments_studentid_foreign" FOREIGN KEY("StudentId") REFERENCES "Students"("Id");
ALTER TABLE
    "CourseComments" ADD CONSTRAINT "coursecomments_adminid_foreign" FOREIGN KEY("AdminId") REFERENCES "Admins"("Id");
ALTER TABLE
    "Courses" ADD CONSTRAINT "courses_categoryid_foreign" FOREIGN KEY("CategoryId") REFERENCES "Categories"("Id");
ALTER TABLE
    "Payment" ADD CONSTRAINT "payment_courseid_foreign" FOREIGN KEY("CourseId") REFERENCES "Courses"("Id");
ALTER TABLE
    "PaymentDetails" ADD CONSTRAINT "paymentdetails_studentid_foreign" FOREIGN KEY("StudentId") REFERENCES "Students"("Id");
ALTER TABLE
    "Videos" ADD CONSTRAINT "videos_coursemodulsid_foreign" FOREIGN KEY("CourseModulsId") REFERENCES "CourseModuls"("Id");