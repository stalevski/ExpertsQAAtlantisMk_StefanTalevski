# ExpertsQAAtlantisMk_StefanTalevski
This solution tests some functionalities on the atlantis.mk website.

## Table of Contents
- [Overview](#overview)
- [Folder Structure](#folder-structure)
- [Setup](#setup)
- [Usage](#usage)
- [Test Cases](#test-cases)
- [Packages Used](#packages-used)

## Overview
This project is a small testing framework implementing the Page Object Model. The tests are run on the atlantis.mk website.

## Folder Structure
The project is organized as follows:

ExpertsQAAtlantisMk_StefanTalevski/
├── LoggingConfig.cs
├── Pages/
│ ├── BasePage.cs
│ ├── HomePage.cs
│ └── ResultsPage.cs
└── Tests/
├── BaseTest.cs
└── HomePageTests.cs

### Pages
- **BasePage**: Contains core functionality and methods common to all pages.
- **HomePage**: Implements specific methods and interactions for the home page.
- **ResultsPage**: Includes methods related to handling search results or similar pages.

### Tests
- **BaseTest**: Provides setup and common utilities for test classes.
- **HomePageTests**: Contains tests specifically targeting the functionality of the home page.

## Setup
Open the solution and build for tests to show in test explorer.

### Prerequisites
- .NET 8
- .NET SDK installed
- Chrome WebDriver or other WebDriver compatible with your browser version

### Installation
Clone the repository:

## Test Cases
- Test_SearchFunctionality: Verify the functionality of searching for vacation details on the home page and navigating to the results page.
- Test_ErrorMessageIsShownIfNoDestinationAndDateIsSelected: Validate that an error message is displayed when attempting to search without selecting a destination and date.

## Packages Used
- dotnetseleniumextras.waithelpers
- nunit
- nunit.engine
- selenium.support
- selenium.webdriver
- selenium.webdriver.chromedriver
- serilog
- serilog.sinks.console
- serilog.sinks.file
