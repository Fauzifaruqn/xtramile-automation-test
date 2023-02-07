Feature: Computer_database

A short summary of the feature

@positive_case @search_computer
Scenario: Search a Computer in Database
	Given I go to Computer Database Page
	When I Type "ASCI Purple" in Computer Search Box
	Then in the table computer contains 
		| computer name | introduced | discontinued | company    |
		| ASCI Purple   | 01 Jan 2005| -			| IBM		 |

@negative_case @non_existing_computer
Scenario: Search for non-existing computer
	Given I go to Computer Database Page
	When I Type "NonExistingComputer" in Computer Search Box
	Then the table should contain message Nothing to display

@create_computer
Scenario: Create a New Computer
	Given I go to Computer Database Page
	When I click Add a new computer button
	And I enter the following details
	  | computer name | introduced | discontinued	| company |
	  | Lenovo Legion 5 | 2022-01-01 | 2023-01-01   | IBM     |
	And I click on the Create this computer button
	Then a computer successfully "created"

@positive_case @delete_computer
Scenario: Delete a Computer
	Given I go to Computer Database Page
	When I Type "lenovo thinkpad r400" in Computer Search Box
	Then in the table computer contains 
		| computer name | introduced | discontinued | company    |
		| lenovo thinkpad r400   | - | -			| -		 |
	And I delete the computer that was searched
	Then a computer successfully "deleted"

@positive_case @update_computer
Scenario: Update a Computer
	Given I go to Computer Database Page
	When I Type "lenovo thinkpad r400" in Computer Search Box
	Then in the table computer contains 
		| computer name | introduced | discontinued | company    |
		| lenovo thinkpad r400   | - | -			| -		 |
	And I updated the computer that was searched
	When I enter the following details
	  | computer name | introduced | discontinued	| company |
	  | lenovo thinkpad Gaming | 2022-01-01 | 2023-01-01   | IBM     |
	And I click on the Save this computer button
	Then a computer successfully "updated"

@negative_case @create_computer_empty_computername
Scenario: user should fail to create a new computer if computer name is empty
	Given I go to Computer Database Page
	When I click Add a new computer button
	And I enter the following details
	  | computer name | introduced | discontinued	| company |
	  |  | 2022-01-01 | 2023-01-01   | IBM     |
	And I click on the Create this computer button
	Then in the computer field "name" an error message will appear "Failed to refine type : Predicate isEmpty() did not fail."

@negative_case @create_computer_fail_discontinued
Scenario: user should fail to create a new computer if Discontinued date is before introduction date
	Given I go to Computer Database Page
	When I click Add a new computer button
	And I enter the following details
	  | computer name | introduced | discontinued	| company |
	  | Lenovo Legion 5 | 2022-01-01 | 2021-01-01   | IBM     |
	And I click on the Create this computer button
	Then in the computer field "discontinued" an error message will appear "Discontinued date is before introduction date"

@negative_case @create_computer_wrong_date_format
Scenario: user should fail to create a new computer if Discontinued or introduced date use wrong format
	Given I go to Computer Database Page
	When I click Add a new computer button
	And I enter the following details
	  | computer name | introduced | discontinued	| company |
	  | Lenovo Legion 5 | 2022/01/01 | 2021/01/01   | IBM     |
	And I click on the Create this computer button
	Then the error message wrong date format will appear

