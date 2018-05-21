Feature: CreateNewUser
	In order to enable more users to enjoy our site
	I want to be able to add new users to the system

Background:
	Given I am using the test user credentials
	| EmailAddress | Password |
	| test@test.test | Test1 |
	And I have not already added the test user to the database
	And I am using the local instance of the website

Scenario: Create a new user with valid details
	When I complete the add user form with the test credentials
	Then the test email address will exist in the database
	And the password will have been hashed
	And the site will show a message indicating the user has been created

Scenario: Can't create user that already exists
	Given I have already added the test user to the database
	When I complete the add user form with the test credentials
	Then the site will show me a message indicating that the user already exists
	And the test email address will not have been added to the database again

Scenario: Submitting without entering details gives error messages
	When I complete the add user form without entering any details
	Then the site will indicate that the email address is required
	And the site will indicate that the password is required

Scenario: Using invalid email address gives error message
	When I complete the add user form with the details
	| EmailAddress | Password |
	| test | Test1 |
	Then the site will indicate that the email address is not valid

Scenario: Using invalid password gives error message
	When I complete the add user form with the details
	| EmailAddress | Password |
	| test@test.com | test |
	Then the site will indicate that the password is not valid

Scenario: Using invalid email address and invalid password shows both error messages
	When I complete the add user form with the details
	| EmailAddress | Password |
	| test | test |
	Then the site will indicate that the email address is not valid
	Then the site will indicate that the password is not valid
