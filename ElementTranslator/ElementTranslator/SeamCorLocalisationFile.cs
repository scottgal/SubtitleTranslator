// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

using System.Text.Json.Serialization;

namespace ElementTranslator;

public class DepartmentListColumn
{
    [JsonPropertyName("name")] public string name { get; set; }

    [JsonPropertyName("description")] public string description { get; set; }

    [JsonPropertyName("insertedByName")] public string insertedByName { get; set; }

    [JsonPropertyName("isActive")] public string isActive { get; set; }

    [JsonPropertyName("updatedDate")] public string updatedDate { get; set; }

    [JsonPropertyName("createdDate")] public string createdDate { get; set; }

    [JsonPropertyName("linkedDepartmentRequestResponses")]
    public string linkedDepartmentRequestResponses { get; set; }

    [JsonPropertyName("linkedUserDepartments")]
    public string linkedUserDepartments { get; set; }

    [JsonPropertyName("departmentUserGroupsRequestResponse")]
    public string departmentUserGroupsRequestResponse { get; set; }
}

public class MATPAGINATOR
{
    [JsonPropertyName("FIRST_PAGE")] public string FIRST_PAGE { get; set; }

    [JsonPropertyName("ITEMS_PER_PAGE")] public string ITEMS_PER_PAGE { get; set; }

    [JsonPropertyName("LAST_PAGE")] public string LAST_PAGE { get; set; }

    [JsonPropertyName("NEXT_PAGE")] public string NEXT_PAGE { get; set; }

    [JsonPropertyName("PREVIOUS_PAGE")] public string PREVIOUS_PAGE { get; set; }

    [JsonPropertyName("OF")] public string OF { get; set; }
}

public class PackagesPage
{
    [JsonPropertyName("Packages")] public string Packages { get; set; }

    [JsonPropertyName("BuyNow")] public string BuyNow { get; set; }

    [JsonPropertyName("TryForFree")] public string TryForFree { get; set; }

    [JsonPropertyName("Features")] public string Features { get; set; }

    [JsonPropertyName("OptionalExtra")] public string OptionalExtra { get; set; }
}

public class Root
{
    [JsonPropertyName("PackagesPage")] public PackagesPage PackagesPage { get; set; }

    [JsonPropertyName("PricingTitle")] public string PricingTitle { get; set; }

    [JsonPropertyName("CurrentPackage")] public string CurrentPackage { get; set; }

    [JsonPropertyName("ChangePlan")] public string ChangePlan { get; set; }

    [JsonPropertyName("FirstName")] public string FirstName { get; set; }

    [JsonPropertyName("LastName")] public string LastName { get; set; }

    [JsonPropertyName("EmailAddress")] public string EmailAddress { get; set; }

    [JsonPropertyName("JobTitle")] public string JobTitle { get; set; }

    [JsonPropertyName("PhoneNumber")] public string PhoneNumber { get; set; }

    [JsonPropertyName("Company")] public string Company { get; set; }

    [JsonPropertyName("Employee")] public string Employee { get; set; }

    [JsonPropertyName("CompanyLanguage")] public string CompanyLanguage { get; set; }

    [JsonPropertyName("Country")] public string Country { get; set; }

    [JsonPropertyName("Marketing")] public string Marketing { get; set; }

    [JsonPropertyName("IAgreeToThe")] public string IAgreeToThe { get; set; }

    [JsonPropertyName("subscriptionAgreement")]
    public string subscriptionAgreement { get; set; }

    [JsonPropertyName("CompanySignup")] public string CompanySignup { get; set; }

    [JsonPropertyName("PlanInformation")] public string PlanInformation { get; set; }

    [JsonPropertyName("Next")] public string Next { get; set; }

    [JsonPropertyName("Back")] public string Back { get; set; }

    [JsonPropertyName("BillingInformation")]
    public string BillingInformation { get; set; }

    [JsonPropertyName("Done")] public string Done { get; set; }

    [JsonPropertyName("IsRequired")] public string IsRequired { get; set; }

    [JsonPropertyName("EmailValidError")] public string EmailValidError { get; set; }

    [JsonPropertyName("SelectOption")] public string SelectOption { get; set; }

    [JsonPropertyName("spaceValidationError")]
    public string spaceValidationError { get; set; }

    [JsonPropertyName("NoOfNamedLicenses")]
    public string NoOfNamedLicenses { get; set; }

    [JsonPropertyName("NoOfConcurrentLicenses")]
    public string NoOfConcurrentLicenses { get; set; }

    [JsonPropertyName("NoOfLightLicenses")]
    public string NoOfLightLicenses { get; set; }

    [JsonPropertyName("TotalPrice")] public string TotalPrice { get; set; }

    [JsonPropertyName("CheckInbox")] public string CheckInbox { get; set; }

    [JsonPropertyName("phoneVlaidError")] public string phoneVlaidError { get; set; }

    [JsonPropertyName("ZeroLicenseCount")] public string ZeroLicenseCount { get; set; }

    [JsonPropertyName("AlreadySavedError")]
    public string AlreadySavedError { get; set; }

    [JsonPropertyName("SuccessfullySaved")]
    public string SuccessfullySaved { get; set; }

    [JsonPropertyName("DefaultLanguage")] public string DefaultLanguage { get; set; }

    [JsonPropertyName("BillingDetail")] public string BillingDetail { get; set; }

    [JsonPropertyName("ClickToOpen")] public string ClickToOpen { get; set; }

    [JsonPropertyName("or")] public string or { get; set; }

    [JsonPropertyName("CardInformation")] public string CardInformation { get; set; }

    [JsonPropertyName("PoweredBy")] public string PoweredBy { get; set; }

    [JsonPropertyName("ConfirmPurchase")] public string ConfirmPurchase { get; set; }

    [JsonPropertyName("BillTo")] public string BillTo { get; set; }

    [JsonPropertyName("YouHaveSelected")] public string YouHaveSelected { get; set; }

    [JsonPropertyName("PackagePlan")] public string PackagePlan { get; set; }

    [JsonPropertyName("MonthlyTotal")] public string MonthlyTotal { get; set; }

    [JsonPropertyName("billingDescription1")]
    public string billingDescription1 { get; set; }

    [JsonPropertyName("billingDescription2")]
    public string billingDescription2 { get; set; }

    [JsonPropertyName("billingDescription3")]
    public string billingDescription3 { get; set; }

    [JsonPropertyName("skipForNow")] public string skipForNow { get; set; }

    [JsonPropertyName("CompanyNameAlreadyExistsError")]
    public string CompanyNameAlreadyExistsError { get; set; }

    [JsonPropertyName("SaveInformation")] public string SaveInformation { get; set; }

    [JsonPropertyName("AppLauncher")] public string AppLauncher { get; set; }

    [JsonPropertyName("Entities")] public string Entities { get; set; }

    [JsonPropertyName("ManageUsersAndRoles")]
    public string ManageUsersAndRoles { get; set; }

    [JsonPropertyName("Jobs")] public string Jobs { get; set; }

    [JsonPropertyName("ManagePartnerSection")]
    public string ManagePartnerSection { get; set; }

    [JsonPropertyName("Schedule")] public string Schedule { get; set; }

    [JsonPropertyName("ManageFeatureSection")]
    public string ManageFeatureSection { get; set; }

    [JsonPropertyName("Reports")] public string Reports { get; set; }

    [JsonPropertyName("ManageVersionSection")]
    public string ManageVersionSection { get; set; }

    [JsonPropertyName("Departments")] public string Departments { get; set; }

    [JsonPropertyName("ManagePackageSection")]
    public string ManagePackageSection { get; set; }

    [JsonPropertyName("Settings")] public string Settings { get; set; }

    [JsonPropertyName("ManageCompanySection")]
    public string ManageCompanySection { get; set; }

    [JsonPropertyName("ManageUserGroupSection")]
    public string ManageUserGroupSection { get; set; }

    [JsonPropertyName("SearchCategory")] public string SearchCategory { get; set; }

    [JsonPropertyName("CreateCategory")] public string CreateCategory { get; set; }

    [JsonPropertyName("Setup")] public string Setup { get; set; }

    [JsonPropertyName("SearchProducts")] public string SearchProducts { get; set; }

    [JsonPropertyName("SearchHere")] public string SearchHere { get; set; }

    [JsonPropertyName("Save")] public string Save { get; set; }

    [JsonPropertyName("Cancel")] public string Cancel { get; set; }

    [JsonPropertyName("Delete")] public string Delete { get; set; }

    [JsonPropertyName("CategoryName")] public string CategoryName { get; set; }

    [JsonPropertyName("AddCategory")] public string AddCategory { get; set; }

    [JsonPropertyName("EditCategory")] public string EditCategory { get; set; }

    [JsonPropertyName("ThisActionWillDeleteCategory")]
    public string ThisActionWillDeleteCategory { get; set; }

    [JsonPropertyName("Permanently")] public string Permanently { get; set; }

    [JsonPropertyName("Confirm?")] public string Confirm { get; set; }

    [JsonPropertyName("CategoryNameIsRequired")]
    public string CategoryNameIsRequired { get; set; }

    [JsonPropertyName("DuplicateCategoryMessage")]
    public string DuplicateCategoryMessage { get; set; }

    [JsonPropertyName("Mustbeatleast8characters")]
    public string Mustbeatleast8characters { get; set; }

    [JsonPropertyName("Mustcontainatleast1number")]
    public string Mustcontainatleast1number { get; set; }

    [JsonPropertyName("Mustcontainatleast1inCapitalCase")]
    public string Mustcontainatleast1inCapitalCase { get; set; }

    [JsonPropertyName("Mustcontainatleast1LetterinSmallCase")]
    public string Mustcontainatleast1LetterinSmallCase { get; set; }

    [JsonPropertyName("Mustcontainatleast1SpecialCharacter")]
    public string Mustcontainatleast1SpecialCharacter { get; set; }

    [JsonPropertyName("NewPassword")] public string NewPassword { get; set; }

    [JsonPropertyName("ConfirmPassword")] public string ConfirmPassword { get; set; }

    [JsonPropertyName("PasswordisRequired")]
    public string PasswordisRequired { get; set; }

    [JsonPropertyName("Passworddonotmatch")]
    public string Passworddonotmatch { get; set; }

    [JsonPropertyName("Set")] public string Set { get; set; }

    [JsonPropertyName("Password")] public string Password { get; set; }

    [JsonPropertyName("Setting")] public string Setting { get; set; }

    [JsonPropertyName("Profile")] public string Profile { get; set; }

    [JsonPropertyName("Logout")] public string Logout { get; set; }

    [JsonPropertyName("DashboardIsUnderDevelopment")]
    public string DashboardIsUnderDevelopment { get; set; }

    [JsonPropertyName("AllRightsReserved")]
    public string AllRightsReserved { get; set; }

    [JsonPropertyName("NoRecordFound")] public string NoRecordFound { get; set; }

    [JsonPropertyName("InformationSuccessfullySaved")]
    public string InformationSuccessfullySaved { get; set; }

    [JsonPropertyName("PaymentDoneSuccessfully")]
    public string PaymentDoneSuccessfully { get; set; }

    [JsonPropertyName("Yourpasswordhasbeenreset")]
    public string Yourpasswordhasbeenreset { get; set; }

    [JsonPropertyName("Successfully")] public string Successfully { get; set; }

    [JsonPropertyName("LogIn")] public string LogIn { get; set; }

    [JsonPropertyName("StripeTokenNull")] public string StripeTokenNull { get; set; }

    [JsonPropertyName("UnableToSetPassword")]
    public string UnableToSetPassword { get; set; }

    [JsonPropertyName("SetPasswordSessionExpired")]
    public string SetPasswordSessionExpired { get; set; }

    [JsonPropertyName("UserNotExist")] public string UserNotExist { get; set; }

    [JsonPropertyName("RecaptchaExpired")] public string RecaptchaExpired { get; set; }

    [JsonPropertyName("Search")] public string Search { get; set; }

    [JsonPropertyName("NoEntriesFound")] public string NoEntriesFound { get; set; }

    [JsonPropertyName("WelcomeTo")] public string WelcomeTo { get; set; }

    [JsonPropertyName("LoginByEnteringInformation")]
    public string LoginByEnteringInformation { get; set; }

    [JsonPropertyName("RememberMe")] public string RememberMe { get; set; }

    [JsonPropertyName("ForgotYourPassword")]
    public string ForgotYourPassword { get; set; }

    [JsonPropertyName("PasswordPatternError")]
    public string PasswordPatternError { get; set; }

    [JsonPropertyName("EmailOrPasswordIncorrect")]
    public string EmailOrPasswordIncorrect { get; set; }

    [JsonPropertyName("SomethingWentWrong")]
    public string SomethingWentWrong { get; set; }

    [JsonPropertyName("CreateGroup")] public string CreateGroup { get; set; }

    [JsonPropertyName("GroupTitle")] public string GroupTitle { get; set; }

    [JsonPropertyName("LevelOfAppearance")]
    public string LevelOfAppearance { get; set; }

    [JsonPropertyName("Global")] public string Global { get; set; }

    [JsonPropertyName("ChangesWillTakePlaceInAllCategories")]
    public string ChangesWillTakePlaceInAllCategories { get; set; }

    [JsonPropertyName("ChangesWillTakePlaceInSpecificCategories")]
    public string ChangesWillTakePlaceInSpecificCategories { get; set; }

    [JsonPropertyName("Submit")] public string Submit { get; set; }

    [JsonPropertyName("CreateColumn")] public string CreateColumn { get; set; }

    [JsonPropertyName("ColumTitle")] public string ColumTitle { get; set; }

    [JsonPropertyName("ColumnTitleIsRequired")]
    public string ColumnTitleIsRequired { get; set; }

    [JsonPropertyName("SpecialCharactersAreNotAllowed")]
    public string SpecialCharactersAreNotAllowed { get; set; }

    [JsonPropertyName("ColumnAlreadyExists")]
    public string ColumnAlreadyExists { get; set; }

    [JsonPropertyName("GroupAlreadyExists")]
    public string GroupAlreadyExists { get; set; }

    [JsonPropertyName("ColumType")] public string ColumType { get; set; }

    [JsonPropertyName("PleaseSelectColumnType")]
    public string PleaseSelectColumnType { get; set; }

    [JsonPropertyName("AddOption")] public string AddOption { get; set; }

    [JsonPropertyName("SelectFromExistingList")]
    public string SelectFromExistingList { get; set; }

    [JsonPropertyName("ChooseFromListBelow")]
    public string ChooseFromListBelow { get; set; }

    [JsonPropertyName("SubUnit")] public string SubUnit { get; set; }

    [JsonPropertyName("PleaseSelectSubUnit")]
    public string PleaseSelectSubUnit { get; set; }

    [JsonPropertyName("DecimalPoints")] public string DecimalPoints { get; set; }

    [JsonPropertyName("5DecimalPoints")] public string _5DecimalPoints { get; set; }

    [JsonPropertyName("SelectValidation")] public string SelectValidation { get; set; }

    [JsonPropertyName("DuplicateTheValue")]
    public string DuplicateTheValue { get; set; }

    [JsonPropertyName("IsSensitive")] public string IsSensitive { get; set; }

    [JsonPropertyName("CreateDropDownList")]
    public string CreateDropDownList { get; set; }

    [JsonPropertyName("CreateComboList")] public string CreateComboList { get; set; }

    [JsonPropertyName("CreateCheckBoxes")] public string CreateCheckBoxes { get; set; }

    [JsonPropertyName("CreateRadioButtons")]
    public string CreateRadioButtons { get; set; }

    [JsonPropertyName("AddUser")] public string AddUser { get; set; }

    [JsonPropertyName("Basic")] public string Basic { get; set; }

    [JsonPropertyName("Permissions")] public string Permissions { get; set; }

    [JsonPropertyName("Finish")] public string Finish { get; set; }

    [JsonPropertyName("Continue")] public string Continue { get; set; }

    [JsonPropertyName("SetupTheBasics")] public string SetupTheBasics { get; set; }

    [JsonPropertyName("FillBasicInformationOfUser")]
    public string FillBasicInformationOfUser { get; set; }

    [JsonPropertyName("SelectUserType")] public string SelectUserType { get; set; }

    [JsonPropertyName("Email")] public string Email { get; set; }

    [JsonPropertyName("Manual")] public string Manual { get; set; }

    [JsonPropertyName("Username")] public string Username { get; set; }

    [JsonPropertyName("SetupLicenseRoles")]
    public string SetupLicenseRoles { get; set; }

    [JsonPropertyName("ChooseWhatLicenseRole")]
    public string ChooseWhatLicenseRole { get; set; }

    [JsonPropertyName("License")] public string License { get; set; }

    [JsonPropertyName("Roles")] public string Roles { get; set; }

    [JsonPropertyName("EditColoumn")] public string EditColoumn { get; set; }

    [JsonPropertyName("GiveUsersAccessPermissiveRole")]
    public string GiveUsersAccessPermissiveRole { get; set; }

    [JsonPropertyName("HasBeenAdded")] public string HasBeenAdded { get; set; }

    [JsonPropertyName("UserDetails")] public string UserDetails { get; set; }

    [JsonPropertyName("Forgot")] public string Forgot { get; set; }

    [JsonPropertyName("EnterEmailToSetForgetPassword")]
    public string EnterEmailToSetForgetPassword { get; set; }

    [JsonPropertyName("BackToLogin")] public string BackToLogin { get; set; }

    [JsonPropertyName("SendEmail")] public string SendEmail { get; set; }

    [JsonPropertyName("CheckYourInbox")] public string CheckYourInbox { get; set; }

    [JsonPropertyName("LogoutSuccessfully")]
    public string LogoutSuccessfully { get; set; }

    [JsonPropertyName("LicenseOccupied")] public string LicenseOccupied { get; set; }

    [JsonPropertyName("UsernameAlreadyExists")]
    public string UsernameAlreadyExists { get; set; }

    [JsonPropertyName("EmailAlreadyExists")]
    public string EmailAlreadyExists { get; set; }

    [JsonPropertyName("LoginSuccessfully")]
    public string LoginSuccessfully { get; set; }

    [JsonPropertyName("PleaseSelectUserType")]
    public string PleaseSelectUserType { get; set; }

    [JsonPropertyName("PleaseSelectAtLeastOneRole")]
    public string PleaseSelectAtLeastOneRole { get; set; }

    [JsonPropertyName("UserCreatedSuccessfully")]
    public string UserCreatedSuccessfully { get; set; }

    [JsonPropertyName("EmailAddressOrUsernameIsRequired")]
    public string EmailAddressOrUsernameIsRequired { get; set; }

    [JsonPropertyName("NamedLicenseAlreadyOccupied")]
    public string NamedLicenseAlreadyOccupied { get; set; }

    [JsonPropertyName("AtLeastOneEmailISRequired")]
    public string AtLeastOneEmailISRequired { get; set; }

    [JsonPropertyName("DeletedSuccessfully")]
    public string DeletedSuccessfully { get; set; }

    [JsonPropertyName("SearchGroup")] public string SearchGroup { get; set; }

    [JsonPropertyName("AddNewGroup")] public string AddNewGroup { get; set; }

    [JsonPropertyName("Groups")] public string Groups { get; set; }

    [JsonPropertyName("SystemGroup")] public string SystemGroup { get; set; }

    [JsonPropertyName("CustomGroup")] public string CustomGroup { get; set; }

    [JsonPropertyName("Columns")] public string Columns { get; set; }

    [JsonPropertyName("AddNewColumn")] public string AddNewColumn { get; set; }

    [JsonPropertyName("SearchColumn")] public string SearchColumn { get; set; }

    [JsonPropertyName("EntityIdentifier")] public string EntityIdentifier { get; set; }

    [JsonPropertyName("Option")] public string Option { get; set; }

    [JsonPropertyName("ThisActionWillDeleteGroup")]
    public string ThisActionWillDeleteGroup { get; set; }

    [JsonPropertyName("AndAssociatedColumns")]
    public string AndAssociatedColumns { get; set; }

    [JsonPropertyName("ThisActionWillDeleteColumn")]
    public string ThisActionWillDeleteColumn { get; set; }

    [JsonPropertyName("Category")] public string Category { get; set; }

    [JsonPropertyName("ThisRecordWasSavedIn")]
    public string ThisRecordWasSavedIn { get; set; }

    [JsonPropertyName("LevelOfAppearanceIsRequired")]
    public string LevelOfAppearanceIsRequired { get; set; }

    [JsonPropertyName("Duplicated")] public string Duplicated { get; set; }

    [JsonPropertyName("Columnsfor")] public string Columnsfor { get; set; }

    [JsonPropertyName("Languages")] public string Languages { get; set; }

    [JsonPropertyName("Users")] public string Users { get; set; }

    [JsonPropertyName("ColumnsView")] public string ColumnsView { get; set; }

    [JsonPropertyName("AddNewItem")] public string AddNewItem { get; set; }

    [JsonPropertyName("ItemsPerPage")] public string ItemsPerPage { get; set; }

    [JsonPropertyName("Of")] public string Of { get; set; }

    [JsonPropertyName("ExpandCategories")] public string ExpandCategories { get; set; }

    [JsonPropertyName("ViewCategories")] public string ViewCategories { get; set; }

    [JsonPropertyName("ColumnAlreadyExistsGlobal")]
    public string ColumnAlreadyExistsGlobal { get; set; }

    [JsonPropertyName("GroupAlreadyExistsGlobal")]
    public string GroupAlreadyExistsGlobal { get; set; }

    [JsonPropertyName("PleaseCreateACategory")]
    public string PleaseCreateACategory { get; set; }

    [JsonPropertyName("AvailableColumns")] public string AvailableColumns { get; set; }

    [JsonPropertyName("SelectColumnsToShowOnList")]
    public string SelectColumnsToShowOnList { get; set; }

    [JsonPropertyName("SelectedColumns")] public string SelectedColumns { get; set; }

    [JsonPropertyName("DragToReorder")] public string DragToReorder { get; set; }

    [JsonPropertyName("Apply")] public string Apply { get; set; }

    [JsonPropertyName("RemoveAllColumns")] public string RemoveAllColumns { get; set; }

    [JsonPropertyName("PleaseSelectAColumn")]
    public string PleaseSelectAColumn { get; set; }

    [JsonPropertyName("Address")] public string Address { get; set; }

    [JsonPropertyName("Item")] public string Item { get; set; }

    [JsonPropertyName("Items")] public string Items { get; set; }

    [JsonPropertyName("Selected")] public string Selected { get; set; }

    [JsonPropertyName("Edit")] public string Edit { get; set; }

    [JsonPropertyName("SearchUserListingHere")]
    public string SearchUserListingHere { get; set; }

    [JsonPropertyName("MAT_PAGINATOR")] public MATPAGINATOR MAT_PAGINATOR { get; set; }

    [JsonPropertyName("Location")] public string Location { get; set; }

    [JsonPropertyName("ProfileOverview")] public string ProfileOverview { get; set; }

    [JsonPropertyName("GeneralInformation")]
    public string GeneralInformation { get; set; }

    [JsonPropertyName("AccountInformation")]
    public string AccountInformation { get; set; }

    [JsonPropertyName("UpcomingTasks")] public string UpcomingTasks { get; set; }

    [JsonPropertyName("Viewing")] public string Viewing { get; set; }

    [JsonPropertyName("UserListColumn")] public UserListColumn UserListColumn { get; set; }

    [JsonPropertyName("ThisActionWillDeleteUser")]
    public string ThisActionWillDeleteUser { get; set; }

    [JsonPropertyName("SelectUserPermissions")]
    public string SelectUserPermissions { get; set; }

    [JsonPropertyName("SystemRoles")] public string SystemRoles { get; set; }

    [JsonPropertyName("SelectTheLicense")] public string SelectTheLicense { get; set; }

    [JsonPropertyName("ChooseLicenseRoleForUser")]
    public string ChooseLicenseRoleForUser { get; set; }

    [JsonPropertyName("SelectTheRole")] public string SelectTheRole { get; set; }

    [JsonPropertyName("GiveUsersPermissiveRole")]
    public string GiveUsersPermissiveRole { get; set; }

    [JsonPropertyName("SelectTheDepartmentRole")]
    public string SelectTheDepartmentRole { get; set; }

    [JsonPropertyName("UserRolesForDepartments")]
    public string UserRolesForDepartments { get; set; }

    [JsonPropertyName("SelectTheEntities")]
    public string SelectTheEntities { get; set; }

    [JsonPropertyName("SelectingEntityMakeYouAdmin")]
    public string SelectingEntityMakeYouAdmin { get; set; }

    [JsonPropertyName("Categories")] public string Categories { get; set; }

    [JsonPropertyName("NoneSelected")] public string NoneSelected { get; set; }

    [JsonPropertyName("YouAlmostDone")] public string YouAlmostDone { get; set; }

    [JsonPropertyName("PleaseCheckVerifyTheInformation")]
    public string PleaseCheckVerifyTheInformation { get; set; }

    [JsonPropertyName("ManageUserSection")]
    public string ManageUserSection { get; set; }

    [JsonPropertyName("Active")] public string Active { get; set; }

    [JsonPropertyName("InActive")] public string InActive { get; set; }

    [JsonPropertyName("AlreadyLogin")] public string AlreadyLogin { get; set; }

    [JsonPropertyName("LicenseCountExceeded")]
    public string LicenseCountExceeded { get; set; }

    [JsonPropertyName("AddMultipleEmailsICardText")]
    public string AddMultipleEmailsICardText { get; set; }

    [JsonPropertyName("Update")] public string Update { get; set; }

    [JsonPropertyName("RecordUpdatedSuccefully")]
    public string RecordUpdatedSuccefully { get; set; }

    [JsonPropertyName("spaceInStringValidationError")]
    public string spaceInStringValidationError { get; set; }

    [JsonPropertyName("All")] public string All { get; set; }

    [JsonPropertyName("Deactivated")] public string Deactivated { get; set; }

    [JsonPropertyName("WarningThisCanNotBeUndone")]
    public string WarningThisCanNotBeUndone { get; set; }

    [JsonPropertyName("AreYouSureYouWantToDeleteThisCategory")]
    public string AreYouSureYouWantToDeleteThisCategory { get; set; }

    [JsonPropertyName("YesDelete")] public string YesDelete { get; set; }

    [JsonPropertyName("AttachFile")] public string AttachFile { get; set; }

    [JsonPropertyName("AttachFiles")] public string AttachFiles { get; set; }

    [JsonPropertyName("AttachMedia")] public string AttachMedia { get; set; }

    [JsonPropertyName("AttachImage")] public string AttachImage { get; set; }

    [JsonPropertyName("AttachImages")] public string AttachImages { get; set; }

    [JsonPropertyName("MaximumAllowedFileSizeIs")]
    public string MaximumAllowedFileSizeIs { get; set; }

    [JsonPropertyName("MaximumAllowedNumberOfFilesIs")]
    public string MaximumAllowedNumberOfFilesIs { get; set; }

    [JsonPropertyName("RemoveAll")] public string RemoveAll { get; set; }

    [JsonPropertyName("AreYouSureYouWantToDelete")]
    public string AreYouSureYouWantToDelete { get; set; }

    [JsonPropertyName("SelectGroupsColumsToShowOnList")]
    public string SelectGroupsColumsToShowOnList { get; set; }

    [JsonPropertyName("AvailableGroups")] public string AvailableGroups { get; set; }

    [JsonPropertyName("SelectedGroups")] public string SelectedGroups { get; set; }

    [JsonPropertyName("Error")] public string Error { get; set; }

    [JsonPropertyName("PleaseSelectSomeColumnsToShow")]
    public string PleaseSelectSomeColumnsToShow { get; set; }

    [JsonPropertyName("Okay")] public string Okay { get; set; }

    [JsonPropertyName("NoItemFound")] public string NoItemFound { get; set; }

    [JsonPropertyName("PleaseConfigure")] public string PleaseConfigure { get; set; }

    [JsonPropertyName("ValueAlreadyExists")]
    public string ValueAlreadyExists { get; set; }

    [JsonPropertyName("CreateDepartment")] public string CreateDepartment { get; set; }

    [JsonPropertyName("AddNewDepartment")] public string AddNewDepartment { get; set; }

    [JsonPropertyName("LinkUsers")] public string LinkUsers { get; set; }

    [JsonPropertyName("DepartmentName")] public string DepartmentName { get; set; }

    [JsonPropertyName("DepartmentDescription")]
    public string DepartmentDescription { get; set; }

    [JsonPropertyName("LinkDepartments")] public string LinkDepartments { get; set; }

    [JsonPropertyName("SelectDepartmentToLinkWithDepartment")]
    public string SelectDepartmentToLinkWithDepartment { get; set; }

    [JsonPropertyName("LinkDepartment")] public string LinkDepartment { get; set; }

    [JsonPropertyName("LinkEntityCategory")]
    public string LinkEntityCategory { get; set; }

    [JsonPropertyName("SelectEntityToLinkWithDepartment")]
    public string SelectEntityToLinkWithDepartment { get; set; }

    [JsonPropertyName("EnterTextHere")] public string EnterTextHere { get; set; }

    [JsonPropertyName("EnterGroupHere")] public string EnterGroupHere { get; set; }

    [JsonPropertyName("SearchDepartment")] public string SearchDepartment { get; set; }

    [JsonPropertyName("SearchEntity")] public string SearchEntity { get; set; }

    [JsonPropertyName("SelectUsers")] public string SelectUsers { get; set; }

    [JsonPropertyName("SelectUserToLinkWithDepartment")]
    public string SelectUserToLinkWithDepartment { get; set; }

    [JsonPropertyName("SelectUserToLinkWithUserGroup")]
    public string SelectUserToLinkWithUserGroup { get; set; }

    [JsonPropertyName("CreateUserGroup")] public string CreateUserGroup { get; set; }

    [JsonPropertyName("SearchUser")] public string SearchUser { get; set; }

    [JsonPropertyName("AvailableUsers")] public string AvailableUsers { get; set; }

    [JsonPropertyName("SelectedUsers")] public string SelectedUsers { get; set; }

    [JsonPropertyName("LinkedUsers")] public string LinkedUsers { get; set; }

    [JsonPropertyName("IsActive")] public string IsActive { get; set; }

    [JsonPropertyName("DepartmentCreatedSuccessfully")]
    public string DepartmentCreatedSuccessfully { get; set; }

    [JsonPropertyName("UserGroupCreatedSuccessfully")]
    public string UserGroupCreatedSuccessfully { get; set; }

    [JsonPropertyName("UserGroupUpdatedSuccessfully")]
    public string UserGroupUpdatedSuccessfully { get; set; }

    [JsonPropertyName("UserGroupNameAlreadyExists")]
    public string UserGroupNameAlreadyExists { get; set; }

    [JsonPropertyName("DepartmentNameAlreadyExists")]
    public string DepartmentNameAlreadyExists { get; set; }

    [JsonPropertyName("UserGroup")] public string UserGroup { get; set; }

    [JsonPropertyName("DepartmentListColumn")]
    public DepartmentListColumn DepartmentListColumn { get; set; }

    [JsonPropertyName("UserGroupListColumn")]
    public UserGroupListColumn UserGroupListColumn { get; set; }

    [JsonPropertyName("ViewDetail")] public string ViewDetail { get; set; }

    [JsonPropertyName("SelectMultipleCategories")]
    public string SelectMultipleCategories { get; set; }

    [JsonPropertyName("SelectAll")] public string SelectAll { get; set; }

    [JsonPropertyName("Clear")] public string Clear { get; set; }

    [JsonPropertyName("FetchRecords")] public string FetchRecords { get; set; }

    [JsonPropertyName("LinkedDepartments")]
    public string LinkedDepartments { get; set; }

    [JsonPropertyName("LinkedEntities")] public string LinkedEntities { get; set; }

    [JsonPropertyName("NoDepartmentsLinked")]
    public string NoDepartmentsLinked { get; set; }

    [JsonPropertyName("NoUsersLinked")] public string NoUsersLinked { get; set; }

    [JsonPropertyName("ThisActionWillDelete")]
    public string ThisActionWillDelete { get; set; }

    [JsonPropertyName("Admin")] public string Admin { get; set; }

    [JsonPropertyName("Restricted")] public string Restricted { get; set; }

    [JsonPropertyName("Standard")] public string Standard { get; set; }

    [JsonPropertyName("ViewOnly")] public string ViewOnly { get; set; }

    [JsonPropertyName("LengthMustBeAtMost32Characters")]
    public string LengthMustBeAtMost32Characters { get; set; }

    [JsonPropertyName("LengthMustBeAtMost128Characters")]
    public string LengthMustBeAtMost128Characters { get; set; }

    [JsonPropertyName("LengthMustBeAtLeast2Characters")]
    public string LengthMustBeAtLeast2Characters { get; set; }

    [JsonPropertyName("SearchDepartmentListingHere")]
    public string SearchDepartmentListingHere { get; set; }

    [JsonPropertyName("SearchUserGroupListingHere")]
    public string SearchUserGroupListingHere { get; set; }

    [JsonPropertyName("Department View Only Admin")]
    public string DepartmentViewOnlyAdmin { get; set; }

    [JsonPropertyName("Department Admin")] public string DepartmentAdmin { get; set; }

    [JsonPropertyName("Department Restricted")]
    public string DepartmentRestricted { get; set; }

    [JsonPropertyName("Department Standard")]
    public string DepartmentStandard { get; set; }

    [JsonPropertyName("Confirmation")] public string Confirmation { get; set; }

    [JsonPropertyName("WithSameNameWasDeletedRecently")]
    public string WithSameNameWasDeletedRecently { get; set; }

    [JsonPropertyName("DoYouWantToRestore")]
    public string DoYouWantToRestore { get; set; }

    [JsonPropertyName("CreateDuplicate")] public string CreateDuplicate { get; set; }

    [JsonPropertyName("Restore")] public string Restore { get; set; }

    [JsonPropertyName("RestoredSuccessfully")]
    public string RestoredSuccessfully { get; set; }

    [JsonPropertyName("RecordExistsInItemTable")]
    public string RecordExistsInItemTable { get; set; }

    [JsonPropertyName("Group")] public string Group { get; set; }

    [JsonPropertyName("Column")] public string Column { get; set; }

    [JsonPropertyName("PleaseSelectAtleastTwoCategories")]
    public string PleaseSelectAtleastTwoCategories { get; set; }

    [JsonPropertyName("ThereIsNoGlobalOrSystemGroupsExists")]
    public string ThereIsNoGlobalOrSystemGroupsExists { get; set; }

    [JsonPropertyName("SelectCategories")] public string SelectCategories { get; set; }

    [JsonPropertyName("UserCannotDeleteItself")]
    public string UserCannotDeleteItself { get; set; }

    [JsonPropertyName("Unit")] public string Unit { get; set; }

    [JsonPropertyName("SelectEntity")] public string SelectEntity { get; set; }

    [JsonPropertyName("SelectCategory")] public string SelectCategory { get; set; }

    [JsonPropertyName("SelectColumnToLink")]
    public string SelectColumnToLink { get; set; }

    [JsonPropertyName("SelectColumnToUpdate")]
    public string SelectColumnToUpdate { get; set; }

    [JsonPropertyName("PleaseSelectUnit")] public string PleaseSelectUnit { get; set; }

    [JsonPropertyName("PleaseSelectEntity")]
    public string PleaseSelectEntity { get; set; }

    [JsonPropertyName("PleaseSelectCategory")]
    public string PleaseSelectCategory { get; set; }

    [JsonPropertyName("PleaseSelectColumnToLink")]
    public string PleaseSelectColumnToLink { get; set; }

    [JsonPropertyName("PleaseSelectColumnToUpdate")]
    public string PleaseSelectColumnToUpdate { get; set; }

    [JsonPropertyName("UploadSignature")] public string UploadSignature { get; set; }

    [JsonPropertyName("NoCategoryToSelect")]
    public string NoCategoryToSelect { get; set; }

    [JsonPropertyName("NoColumnToSelect")] public string NoColumnToSelect { get; set; }

    [JsonPropertyName("ColumnCantBeDeletedItIsLinked")]
    public string ColumnCantBeDeletedItIsLinked { get; set; }

    [JsonPropertyName("PleaseConfirmYourSignature")]
    public string PleaseConfirmYourSignature { get; set; }

    [JsonPropertyName("ConfirmSignature")] public string ConfirmSignature { get; set; }

    [JsonPropertyName("YouAreUpdatingTheStateOfGroup")]
    public string YouAreUpdatingTheStateOfGroup { get; set; }

    [JsonPropertyName("AllDataStoredInPreviousStateWillLose")]
    public string AllDataStoredInPreviousStateWillLose { get; set; }

    [JsonPropertyName("AreYouSureYouWantToUpdate")]
    public string AreYouSureYouWantToUpdate { get; set; }

    [JsonPropertyName("ThisActionCantBeUnDone")]
    public string ThisActionCantBeUnDone { get; set; }

    [JsonPropertyName("AllDataSavedInThisColumnWillLose")]
    public string AllDataSavedInThisColumnWillLose { get; set; }

    [JsonPropertyName("AllDataSavedInTheColumnsOfThisGroupWillLose")]
    public string AllDataSavedInTheColumnsOfThisGroupWillLose { get; set; }

    [JsonPropertyName("ColumnCantBeUpdateItIsLinked")]
    public string ColumnCantBeUpdateItIsLinked { get; set; }

    [JsonPropertyName("GroupCantBeDeletedItHasColumnWhichIsLinkedWithOtherEntity")]
    public string GroupCantBeDeletedItHasColumnWhichIsLinkedWithOtherEntity { get; set; }

    [JsonPropertyName("ColumnNameCantBeSameAsGroup")]
    public string ColumnNameCantBeSameAsGroup { get; set; }

    [JsonPropertyName("AlreadyExists")] public string AlreadyExists { get; set; }

    [JsonPropertyName("Check")] public string Check { get; set; }

    [JsonPropertyName("SubCheck")] public string SubCheck { get; set; }

    [JsonPropertyName("ExecuteAlways")] public string ExecuteAlways { get; set; }

    [JsonPropertyName("EqualTo")] public string EqualTo { get; set; }

    [JsonPropertyName("NotEqualTo")] public string NotEqualTo { get; set; }

    [JsonPropertyName("LessThan")] public string LessThan { get; set; }

    [JsonPropertyName("GreaterThan")] public string GreaterThan { get; set; }

    [JsonPropertyName("Between")] public string Between { get; set; }

    [JsonPropertyName("NotBetween")] public string NotBetween { get; set; }

    [JsonPropertyName("ConditionIsRequired")]
    public string ConditionIsRequired { get; set; }

    [JsonPropertyName("Task")] public string Task { get; set; }

    [JsonPropertyName("CreateTask")] public string CreateTask { get; set; }

    [JsonPropertyName("CreateNewTask")] public string CreateNewTask { get; set; }

    [JsonPropertyName("ViewTask")] public string ViewTask { get; set; }

    [JsonPropertyName("TaskDeleted")] public string TaskDeleted { get; set; }

    [JsonPropertyName("TaskCreated")] public string TaskCreated { get; set; }

    [JsonPropertyName("TaskUpdated")] public string TaskUpdated { get; set; }

    [JsonPropertyName("TaskName")] public string TaskName { get; set; }

    [JsonPropertyName("SelectDepartment")] public string SelectDepartment { get; set; }

    [JsonPropertyName("TaskAndSelectDept")]
    public string TaskAndSelectDept { get; set; }

    [JsonPropertyName("SelectEntityCategory")]
    public string SelectEntityCategory { get; set; }

    [JsonPropertyName("AvailableEntity")] public string AvailableEntity { get; set; }

    [JsonPropertyName("TaskExits")] public string TaskExits { get; set; }

    [JsonPropertyName("SelectDept")] public string SelectDept { get; set; }

    [JsonPropertyName("SelectEntityAndCategory")]
    public string SelectEntityAndCategory { get; set; }

    [JsonPropertyName("ManageTasksSection")]
    public string ManageTasksSection { get; set; }

    [JsonPropertyName("Format")] public string Format { get; set; }

    [JsonPropertyName("RegularExpression")]
    public string RegularExpression { get; set; }

    [JsonPropertyName("SizeLimit")] public string SizeLimit { get; set; }

    [JsonPropertyName("AllowedDecimalPoints")]
    public string AllowedDecimalPoints { get; set; }

    [JsonPropertyName("NoDecimalPoints")] public string NoDecimalPoints { get; set; }

    [JsonPropertyName("FiveDecimalAllowed")]
    public string FiveDecimalAllowed { get; set; }

    [JsonPropertyName("SureDelete")] public string SureDelete { get; set; }

    [JsonPropertyName("CreateCheck")] public string CreateCheck { get; set; }

    [JsonPropertyName("AddTrigger")] public string AddTrigger { get; set; }

    [JsonPropertyName("IfAnswer")] public string IfAnswer { get; set; }

    [JsonPropertyName("CheckName")] public string CheckName { get; set; }

    [JsonPropertyName("RunCheck")] public string RunCheck { get; set; }

    [JsonPropertyName("ColumnSameDeleted")]
    public string ColumnSameDeleted { get; set; }

    [JsonPropertyName("AddCheck")] public string AddCheck { get; set; }

    [JsonPropertyName("ShowGroup")] public string ShowGroup { get; set; }

    [JsonPropertyName("DoNotHaveTriggers")]
    public string DoNotHaveTriggers { get; set; }

    [JsonPropertyName("InList")] public string InList { get; set; }

    [JsonPropertyName("NotInList")] public string NotInList { get; set; }

    [JsonPropertyName("MinMaxValue")] public string MinMaxValue { get; set; }

    [JsonPropertyName("RedirectToHomePage")]
    public string RedirectToHomePage { get; set; }

    [JsonPropertyName("AllowedFilesLimit")]
    public string AllowedFilesLimit { get; set; }

    [JsonPropertyName("MyBusiness")] public string MyBusiness { get; set; }

    [JsonPropertyName("ExpandAll")] public string ExpandAll { get; set; }

    [JsonPropertyName("CollapseAll")] public string CollapseAll { get; set; }

    [JsonPropertyName("CheckType")] public string CheckType { get; set; }

    [JsonPropertyName("LoopCount")] public string LoopCount { get; set; }

    [JsonPropertyName("PleaseAttachAnImage")]
    public string PleaseAttachAnImage { get; set; }

    [JsonPropertyName("IsPhotoCombo")] public string IsPhotoCombo { get; set; }

    [JsonPropertyName("AllowOtherOption")] public string AllowOtherOption { get; set; }

    [JsonPropertyName("ImageAlreadyAttachePleaseRemoveItFirst.")]
    public string ImageAlreadyAttachePleaseRemoveItFirst { get; set; }

    [JsonPropertyName("SelectedEntites")] public string SelectedEntites { get; set; }

    [JsonPropertyName("SelectedColumnToLink")]
    public string SelectedColumnToLink { get; set; }

    [JsonPropertyName("position")] public string position { get; set; }

    [JsonPropertyName("versionNumber")] public string versionNumber { get; set; }

    [JsonPropertyName("taskName")] public string taskName { get; set; }

    [JsonPropertyName("departmentName")] public string departmentName { get; set; }

    [JsonPropertyName("startDate")] public string startDate { get; set; }

    [JsonPropertyName("endDate")] public string endDate { get; set; }

    [JsonPropertyName("abortReason")] public string abortReason { get; set; }

    [JsonPropertyName("sessionNumber")] public string sessionNumber { get; set; }

    [JsonPropertyName("status")] public string status { get; set; }

    [JsonPropertyName("Abort")] public string Abort { get; set; }

    [JsonPropertyName("selectStartDate")] public string selectStartDate { get; set; }

    [JsonPropertyName("selectEndDate")] public string selectEndDate { get; set; }

    [JsonPropertyName("entityName")] public string entityName { get; set; }

    [JsonPropertyName("categoryName")] public string categoryName { get; set; }

    [JsonPropertyName("itemName")] public string itemName { get; set; }

    [JsonPropertyName("AddNewBarcodeSequence")]
    public string AddNewBarcodeSequence { get; set; }

    [JsonPropertyName("BarcodeDescription")]
    public string BarcodeDescription { get; set; }

    [JsonPropertyName("DescriptionIsRequired")]
    public string DescriptionIsRequired { get; set; }

    [JsonPropertyName("StartDigit")] public string StartDigit { get; set; }

    [JsonPropertyName("StartDigitIsRequired")]
    public string StartDigitIsRequired { get; set; }

    [JsonPropertyName("LastDigit")] public string LastDigit { get; set; }

    [JsonPropertyName("EndDigitIsRequired")]
    public string EndDigitIsRequired { get; set; }

    [JsonPropertyName("BarcodeSequenceDataType")]
    public string BarcodeSequenceDataType { get; set; }

    [JsonPropertyName("EndDigitisRequired")]
    public string EndDigitisRequired { get; set; }

    [JsonPropertyName("SelectBarcodeSequenceInputType")]
    public string SelectBarcodeSequenceInputType { get; set; }

    [JsonPropertyName("BarcodeInputTypeIsRequired")]
    public string BarcodeInputTypeIsRequired { get; set; }

    [JsonPropertyName("EndDigitIsAlreadyTaken")]
    public string EndDigitIsAlreadyTaken { get; set; }

    [JsonPropertyName("EndDigitCannotBeZero")]
    public string EndDigitCannotBeZero { get; set; }

    [JsonPropertyName("StartDigitIsAlreadyTaken")]
    public string StartDigitIsAlreadyTaken { get; set; }

    [JsonPropertyName("StartDigitCannotBeZero")]
    public string StartDigitCannotBeZero { get; set; }

    [JsonPropertyName("Suspended")] public string Suspended { get; set; }

    [JsonPropertyName("Resume")] public string Resume { get; set; }

    [JsonPropertyName("ItemNotMatched")] public string ItemNotMatched { get; set; }

    [JsonPropertyName("ItemMatched")] public string ItemMatched { get; set; }

    [JsonPropertyName("PleaseCreateBarcodeSequenceToProceed!")]
    public string PleaseCreateBarcodeSequenceToProceed { get; set; }

    [JsonPropertyName("AlreadyActiveSession")]
    public string AlreadyActiveSession { get; set; }

    [JsonPropertyName("DepartmentCantDeletedTaskExists")]
    public string DepartmentCantDeletedTaskExists { get; set; }

    [JsonPropertyName("UniqueKeyViolation")]
    public string UniqueKeyViolation { get; set; }

    [JsonPropertyName("RegisterCompanyLPUser")]
    public string RegisterCompanyLPUser { get; set; }

    [JsonPropertyName("SameUserExists")] public string SameUserExists { get; set; }

    [JsonPropertyName("DoYouWantToInviteUser")]
    public string DoYouWantToInviteUser { get; set; }

    [JsonPropertyName("InviteUser")] public string InviteUser { get; set; }

    [JsonPropertyName("AddLPUser")] public string AddLPUser { get; set; }
}

public class UserGroupListColumn
{
    [JsonPropertyName("name")] public string name { get; set; }

    [JsonPropertyName("description")] public string description { get; set; }

    [JsonPropertyName("insertedByName")] public string insertedByName { get; set; }

    [JsonPropertyName("isActive")] public string isActive { get; set; }

    [JsonPropertyName("updatedDate")] public string updatedDate { get; set; }

    [JsonPropertyName("createdDate")] public string createdDate { get; set; }

    [JsonPropertyName("linkedUsersObject")]
    public string linkedUsersObject { get; set; }
}

public class UserListColumn
{
    [JsonPropertyName("address")] public string address { get; set; }

    [JsonPropertyName("companyName")] public string companyName { get; set; }

    [JsonPropertyName("countryName")] public string countryName { get; set; }

    [JsonPropertyName("email")] public string email { get; set; }

    [JsonPropertyName("firstName")] public string firstName { get; set; }

    [JsonPropertyName("lastName")] public string lastName { get; set; }

    [JsonPropertyName("insertedByName")] public string insertedByName { get; set; }

    [JsonPropertyName("isActive")] public string isActive { get; set; }

    [JsonPropertyName("jobTitle")] public string jobTitle { get; set; }

    [JsonPropertyName("lastLogout")] public string lastLogout { get; set; }

    [JsonPropertyName("lastLogin")] public string lastLogin { get; set; }

    [JsonPropertyName("loginTypeName")] public string loginTypeName { get; set; }

    [JsonPropertyName("licenseTypeName")] public string licenseTypeName { get; set; }

    [JsonPropertyName("phoneNumber")] public string phoneNumber { get; set; }

    [JsonPropertyName("roleNames")] public string roleNames { get; set; }

    [JsonPropertyName("userName")] public string userName { get; set; }

    [JsonPropertyName("departmentName")] public string departmentName { get; set; }
}