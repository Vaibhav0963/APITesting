Feature: SampleAPI
checking Dummy API's

@dummyAPI
Scenario: GET Request
	When user sends GET request
	Then user should be able to verify employees with GET requests

Scenario: POST Request with table
	When user sends POST request
	| prop     | value   |
	|   name   | vaibhav |
	|   salary | 15750   |
	|   age    |   22    |
	Then user should be able to create new employee and verify POST request

Scenario: DELETE Request
	When user sends DELETE request
	Then user should be able to delete employees details

Scenario: GET Request for newly created employees
	When user sends GET request of newly created employee
	Then user should be able to verify new employee with GET request



