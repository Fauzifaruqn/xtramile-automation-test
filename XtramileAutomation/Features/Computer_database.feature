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