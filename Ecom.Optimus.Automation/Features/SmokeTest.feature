Feature: Ecom Optimus Test Automation
        Smoke test scenarios

@smoke
Scenario: Test login
     Given I login to application

@smoke
Scenario: Search for an item
     Given I login to application
     When I search for item round neck shirts
	 And I select an item from results 
	 And I click Add to cart button
	 Then I click on view cart button
	 And I validate correct item is added
	 And I return to home page

@smoke
Scenario: Add different sizes of shirts
      Given I login to application
	  When I search for item round neck shirts
	  And I select an item from results
	  And I select pick random 3 sizes of item
	  And I click Add to cart button
	  Then I click on view cart button
	  And I validate correct item is added
	  And I return to home page

@Smoke
Scenario: To add an item from Collections
       Given I login to application
	   And I scroll down to collections
	   When I click Add to cart button
	   Then I click on view cart button
	   And I return to home page