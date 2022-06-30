using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using APITesting.FeatureFiles;
using System.IO;
using TechTalk.SpecFlow;

namespace APITesting.CommonMethodObjects
{
    [Binding]
   public class DummyAPIObjects
    {
        public string baseURL = "https://dummy.restapiexample.com";
        public RestResponse Response;
        public dynamic id;

        public void GetEmployeeRequest()
        {
            RestClient client = new RestClient(baseURL);
            RestRequest request = new RestRequest("/employees", Method.Get);
            Response = client.Execute(request);
        }

        public void VerifyGetResult()
        {
            dynamic deserializeAPI = JsonConvert.DeserializeObject(Response.Content);
            var value = deserializeAPI.data[0].employee_name;
            Assert.AreEqual("Tiger Nixon", value.Value);
            Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public void PostEmployeeRequest(string name, string salary, string age)
        {
            RestClient client = new RestClient(baseURL);
            RestRequest request = new RestRequest("/create", Method.Post);
            int sal = Convert.ToInt32(salary);
            int Age = Convert.ToInt32(age);
            var dummy = "{\"name\":\"" + name + "\",\"salary\":"+sal+",\"age\":"+Age+"}";
            request.AddBody(dummy);
            Response = client.Execute(request);
        }

        public void VerifyPostRequest()
        {
            dynamic deserializeAPI = JsonConvert.DeserializeObject(Response.Content);
            //dynamic desiralizeAPI=Newtonsoft.Json.JsonConvert.DeserializeObject(Response.Content);
            //dynamic desiralizeAPI = JsonConvert.DeserializeObject(Response.Content);
            var value = deserializeAPI.data.name;
            Assert.AreEqual("vaibhav", value.Value);
            Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            id = deserializeAPI.data.id.Value;
            CreateTxtFile();
        }

        public void CreateTxtFile()
        {
            string folder = @"C:\Users\mindtreejanedge233\source\repos\APITesting\APITesting\id.txt";
            try
            {
                //checking if the file already exixt.If yes, delete it.
                if (File.Exists(folder))
                {
                    File.Delete(folder);
                }

                //Create New File
                using (FileStream fs = File.Create(folder))
                {
                    //Add some text to file
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("Automation");
                    fs.Write(author, 0, author.Length);

                }
                //Create a text
                using (StreamWriter sq = File.CreateText(folder))
                {
                    sq.WriteLine(id);
                }
            }
            catch
            {

            }
        }
        public void ReadTxtFile()
        {
            string folder = @"C:\Users\mindtreejanedge233\source\repos\APITesting\APITesting\id.txt";
            using (StreamReader sr = File.OpenText(folder))
            {
                string s = "";
                while((s=sr.ReadLine())!=null)
                {
                    Console.WriteLine(s);
                    id = s;
                }
            }
        }
        public void DeleteEmployeeRequest()
        {
            RestClient client = new RestClient(baseURL);
            ReadTxtFile();
            RestRequest request = new RestRequest("/delete" + id, Method.Delete);
            Response = client.Execute(request);
        }

        public void VerifyDeleteRequest()
        {
            Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        public void GetNewEmployeeRequest()
        {
            RestClient client = new RestClient(baseURL);
            RestRequest request = new RestRequest("/employees"+id, Method.Get);
            Response = client.Execute(request);
        }

        public void VerifyNewEmployeeGetResult()
        {
            dynamic deserializeAPI = Newtonsoft.Json.JsonConvert.DeserializeObject(Response.Content);
            var value = deserializeAPI.data[0].employee_name;
            Assert.AreEqual("vaibhav", value.Value);
            Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
