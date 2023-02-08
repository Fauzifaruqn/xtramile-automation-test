Feature: Java Script Alert

A short summary of the feature

Scenario: User should be able to Click JS Alert
	Given I go to Javascript Alert Page
	When I click on the "Click for JS Alert" button
	Then I should see an alert message with text "I am a JS Alert"
	And I accept the alert
	And I should see the message "You successfully clicked an alert"


Scenario: User should be able Click Ok for JS Confirm
	Given I go to Javascript Alert Page
	When I click on the "Click for JS Confirm" button
	Then I should see an confirm message with text "I am a JS Confirm"
	And I click Ok in the confirm 
	And I should see the message "You clicked: Ok"

Scenario: User should be able Click Cancel for JS Confirm
	Given I go to Javascript Alert Page
	When I click on the "Click for JS Confirm" button
	Then I should see an confirm message with text "I am a JS Confirm"
	And I cancel the confirm
	And I should see the message "You clicked: Cancel"

Scenario: User should be able Click for JS Prompt
	Given I go to Javascript Alert Page
	When I click on the "Click for JS Prompt" button
	Then I should see an confirm message with text "I am a JS prompt"	
	And I type "My Name is Fauzi" in the prompt and press OK
	And I should see the message "You entered: My Name is Fauzi"