# Selenium UI tests for ShopTARge24

This repository contains an MSTest Selenium UI test project for the **ShopTARge24** web application.

## Project

- **Test project:** `SeleniumShopUITests`
- **Framework:** .NET 9 + MSTest
- **Browser:** Chrome (Selenium WebDriver)

## Tested features (KindergartenTest)

The tests cover the `KindergartenTest` area in the ShopTARge24 application:

1. **Navigation**
   - Test: `CanNavigateToKindergartenTestIndex`
   - Checks that the *Kindergarten (test)* menu link opens the correct index page and the page header is *"Kindergarten"*.

2. **Create**
   - Test: `CanCreateKindergartenWithValidData`
     - Fills the *Create kindergarten* form with valid data and verifies that a new row appears in the index table.
   - Test: `CannotCreateKindergartenWithInvalidChildrenNumber`
     - Tries to save the form with an invalid value in the *ChildrenCount* field (text instead of number) and checks that validation error is shown and the record is not created.

3. **Details**
   - Test: `CanOpenKindergartenDetails`
     - Takes the first row from the index table, clicks **Details**, and checks that the *Details* page opens.

4. **Edit**
   - Tests: `CanEditKindergartenWithValidData`, `CannotEditKindergartenWithInvalidChildrenNumber`
     - Valid edit: changes data in the edit form and verifies that the updated values appear in the index table.
     - Invalid edit: uses an incorrect value type for *ChildrenCount* and checks that validation prevents saving.

5. **Delete**
   - Test: `CanDeleteKindergarten`
     - Deletes the first kindergarten from the index table and verifies that this row is no longer visible after returning to the index page.

## How to run tests

1. Start the **ShopTARge24** web application (branch `feature/kindergarten-selenium-copy`).
   - The application must be available at `https://localhost:7282/`.
2. Open the solution `SeleniumTestsShopTARge24` in Visual Studio.
3. Build the solution.
4. Open **Test Explorer**.
5. Run all tests in the `SeleniumShopUITests` project.

by Sepp 2025
