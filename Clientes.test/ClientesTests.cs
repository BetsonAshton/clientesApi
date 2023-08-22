using Bogus;
using Bogus.Extensions.Brazil;
using ClientesApi.Application.Models.Requests;
using ClientesApi.Application.Models.Responses;
using ClientesApi.Domain.Entities;
using ClientesApi.test.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClientesApi.test
{
    public class ClientesTests
    {
        private const string? endpoint = "api/Cliente";

        [Fact]
        public async Task Test_Cliente_Post_Returns_Created()
        {
            var faker = new Faker("pt_BR");
            var request = new ClientesCreateRequest
            {
                Nome = faker.Person.FullName.Replace(".", string.Empty),
                Email = faker.Person.Email,
                Telefone = faker.Phone.PhoneNumber("(##)#########"),
                Cpf = faker.Person.Cpf(false)
            };

            var response = TestsHelper.CreateClient.PostAsync
                (endpoint, TestsHelper.CreateContent(request)).Result;

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);


        }

        [Fact]

        public async Task Test_Clientes_Put_Returns_Ok()
        {
            var resultCadastro = Test_Cliente_Post_Returns_Created();

            var faker = new Faker("pt_BR");
            var request = new ClientesUpdateRequest
            {
                //Id = resultCadastro.Id, 
                Nome = faker.Person.FullName.Replace(".", string.Empty),
                Email = faker.Person.Email,
                Telefone = faker.Phone.PhoneNumber("(##)#########")
            };

            var response = TestsHelper.CreateClient.PutAsync
                (endpoint, TestsHelper.CreateContent(request)).Result;

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

        }
    }
}

