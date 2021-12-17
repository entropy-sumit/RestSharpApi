using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using RestSharp;

namespace RestSharpTest

{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
    }
    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000");
        }
        private IRestResponse GetEmployeeList()
        {
            RestRequest request = new RestRequest("/emplyees", Method.GET);

            IRestResponse response = client.Execute(request);
            return response;
        }

        //[TestMethod]
        //public void ReturnEmployeeList()
        //{
        //    IRestResponse response = GetEmployeeList();
        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //    List<Employee> employeeList = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
        //    Assert.AreEqual(4, employeeList.Count);
        //    foreach (Employee emp in employeeList)
        //    {
        //        Console.WriteLine("id: " + emp.id + "\t" + "name: " + emp.name + "\t" + "salary: " + emp.salary);
        //    }
        //}

        //[TestMethod]
        //public void OnCallingPostAPIForAEmployeeListWithMultipleEMployees_ReturnEmployeeObject()
        //{
        //    List<Employee> employeeList = new List<Employee>();
        //    employeeList.Add(new Employee { name = "Radha", salary = "85536" });
        //    employeeList.Add(new Employee { name = "Watson", salary = "120123" });
        //    employeeList.Add(new Employee { name = "Christiano Ronaldo", salary = "123456" });

        //    foreach (var emp in employeeList)
        //    {

        //        RestRequest request = new RestRequest("emplyees", Method.POST);
        //        JsonObject jsonObj = new JsonObject();
        //        jsonObj.Add("name", emp.name);
        //        jsonObj.Add("salary", emp.salary);

        //        request.AddParameter("application/json", jsonObj, ParameterType.RequestBody);
        //        IRestResponse response = client.Execute(request);

        //        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        //        Employee employee = JsonConvert.DeserializeObject<Employee>(response.Content);
        //        Assert.AreEqual(emp.name, employee.name);
        //        Assert.AreEqual(emp.salary, employee.salary);
        //        Console.WriteLine(response.Content);
        //    }
        //}

        [TestMethod]
        public void OnCallingPutAPI_ReturnEmployeeObject()
        {
            RestRequest request = new RestRequest("emplyees", Method.PUT);
            JsonObject jsonObj = new JsonObject();
            jsonObj.Add("id", "8");
            jsonObj.Add("salary", "35000");
            request.AddParameter("application/json", jsonObj, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Employee employee = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("8", employee.id);
            Assert.AreEqual("35000", employee.salary);
            Console.WriteLine(response.Content);
        }
        //[TestMethod]
        //public void OnCallingDeleteAPI_ReturnSuccessStatus()
        //{
        //    RestRequest request = new RestRequest("/emplyees/", Method.DELETE);

        //    IRestResponse response = client.Execute(request);

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //    Console.WriteLine(response.Content);
        //}
    }
}
