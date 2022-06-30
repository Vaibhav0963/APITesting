using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using APITesting.CommonMethodObjects;
using APITesting.FeatureFiles;

namespace APITesting.FeatureFiles
{
    [Binding]
    public class SampleAPISteps
    {
        DummyAPIObjects objAPI = new DummyAPIObjects();
        [When(@"user sends GET request")]
        public void WhenUserSendsGETRequest()
        {
            objAPI.GetEmployeeRequest();
        }
        
        [When(@"user sends POST request")]
        public void WhenUserSendsPOSTRequest(Table table)
        {
         foreach(TableRow row in table.Rows)
            {
                foreach (String value in row.Values)
                    Console.WriteLine(value);
            }
        }
        
        [When(@"user sends DELETE request")]
        public void WhenUserSendsDELETERequest()
        {
            objAPI.DeleteEmployeeRequest();
        }
        
        [When(@"user sends GET request of newly created employee")]
        public void WhenUserSendsGETRequestOfNewlyCreatedEmployee()
        {
            objAPI.GetNewEmployeeRequest();
        }
        
        [Then(@"user should be able to verify employees with GET requests")]
        public void ThenUserShouldBeAbleToVerifyEmployeesWithGETRequests()
        {
           objAPI.VerifyGetResult();
        }
        
        [Then(@"user should be able to create new employee and verify POST request")]
        public void ThenUserShouldBeAbleToCreateNewEmployeeAndVerifyPOSTRequest()
        {
           objAPI.VerifyPostRequest();
        }
        
        [Then(@"user should be able to delete employees details")]
        public void ThenUserShouldBeAbleToDeleteEmployeesDetails()
        {
            objAPI.VerifyDeleteRequest();
        }
        
        [Then(@"user should be able to verify new employee with GET request")]
        public void ThenUserShouldBeAbleToVerifyNewEmployeeWithGETRequest()
        {
            objAPI.VerifyNewEmployeeGetResult();
        }
    }
}
