﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [DataRequestApplications] (
    [Id] int NOT NULL IDENTITY,
    [OrganisationLegalName] nvarchar(255) NOT NULL,
    [OrganisationABN] nvarchar(11) NOT NULL,
    [OrganisationPhysicalAddress] nvarchar(500) NOT NULL,
    [AuthorisedUsers] nvarchar(500) NOT NULL,
    [AuthorisedSignatoryName] nvarchar(255) NOT NULL,
    [AuthorisedSignatoryPosition] nvarchar(255) NOT NULL,
    [EmailAddress] nvarchar(100) NOT NULL,
    [NAPLAN_IsCurrentYear] bit NOT NULL,
    [NAPLAN_IsAllYears] bit NOT NULL,
    [NAPLAN_SimilarSchools_IsCurrentYear] bit NOT NULL,
    [NAPLAN_SimilarSchools_IsAllYears] bit NOT NULL,
    [NAPLAN_SimpleStudentGain_IsCurrentYear] bit NOT NULL,
    [NAPLAN_SimpleStudentGain_IsAllYears] bit NOT NULL,
    [NAPLAN_SameStartingScoreGain_IsCurrentYear] bit NOT NULL,
    [NAPLAN_SameStartingScoreGain_IsAllYears] bit NOT NULL,
    [NAPLAN_SimilarSchoolsGain_IsCurrentYear] bit NOT NULL,
    [NAPLAN_SimilarSchoolsGain_IsAllYears] bit NOT NULL,
    [SchoolAttendance_IsCurrentYear] bit NOT NULL,
    [SchoolAttendance_IsAllYears] bit NOT NULL,
    [SeniorSecondary_IsCurrentYear] bit NOT NULL,
    [SeniorSecondary_IsAllYears] bit NOT NULL,
    [VETInSchools_IsCurrentYear] bit NOT NULL,
    [VETInSchools_IsAllYears] bit NOT NULL,
    [Finance_IsCurrentYear] bit NOT NULL,
    [Finance_IsAllYears] bit NOT NULL,
    [EnrolmentsByGrade_IsCurrentYear] bit NOT NULL,
    [EnrolmentsByGrade_IsAllYears] bit NOT NULL,
    [StudentLevelDeidentified_IsCurrentYear] bit NOT NULL,
    [StudentLevelDeidentified_IsAllYears] bit NOT NULL,
    [CustomisedRequestText] nvarchar(500) NULL,
    [CustomisedRequest_IsCurrentYear] bit NOT NULL,
    [CustomisedRequest_IsAllYears] bit NOT NULL,
    [DetailedDescriptionOfTheIntendedUse] text NOT NULL,
    [PlannedProductsFromTheDataProvided] nvarchar(max) NOT NULL,
    [LicensePeriod] datetime2 NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT '2018-06-28T15:50:34.3490000+07:00',
    [Status] int NOT NULL,
    [Version] rowversion NULL,
    CONSTRAINT [PK_DataRequestApplications] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180628085034_InitDatabase', N'2.1.1-rtm-30846');

GO

