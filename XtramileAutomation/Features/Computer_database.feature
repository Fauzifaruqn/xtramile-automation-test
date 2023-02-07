Feature: Computer_database

A short summary of the feature

@tag1
Scenario: Search a Computer in Database
	Given I go to Computer Database Page
	When I Type "ASCI Purple" in Computer Search Box
	Then in the table computer contains 
		| computer name | introduced | discontinued | company    |
		| ASCI Purple   | 01 Jan 2005| -			| IBM		 |

Scenario: Search for non-existing computer
	Given I go to Computer Database Page
	When I Type "NonExistingComputer" in Computer Search Box
	Then the table should contain message Nothing to display

Scenario: Create a New Computer
	Given I go to Computer Database Page
	When I click Add a new computer button
	And I enter the following details
	  | computer name | introduced | discontinued	| company |
	  | Lenovo Legion 5 | 2022-01-01 | 2023-01-01   | IBM     |
	And I click on the Create this computer button
	Then a new computer successfully created