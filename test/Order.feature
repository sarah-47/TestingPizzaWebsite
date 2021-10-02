Feature: Order

Scenario: Order pizza from pizza website
	Given i'm in the menu page
	Then l click order button
	Then i click the cart link
	Then i click the remove button
	Then i click the Confirm Order
	Then i should go to the order Confirm page
	Then Close the browser