﻿Feature: Ecom Optimus Test Automation
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@smoke
Scenario: Test login
     Given I login to application

@smoke
Scenario: Search for an item
     Given I login to application
	 When I search for round neck shirt item
	 And I select an item from results 
	 And I click Add to cart button
	 Then I click on view cart button
	 And I return to home page

Scenario: Add different sizes of shirts
      Given I login to application
	  When I search for round neck shirt item
	  And I select an item from results
	  And I select pick random 3 sizes of item
	  And I click Add to cart button
	  Then I click on view cart button
	  And I return to home page