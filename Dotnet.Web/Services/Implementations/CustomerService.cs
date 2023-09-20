using Dotnet.Web.Models;
using Dotnet.Web.Services.Interfaces;
using System.Text.Json;

namespace Dotnet.Web.Services.Implementations;

public class CustomerService : ICustomerService
{

    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    
    public CustomerService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _apiBaseUrl = _configuration.GetValue<string>("ApiBaseUrl");
        _httpClient = httpClient;
    }
    
    
    public async Task<List<CustomerModel>> GetCustomerList()
    {
        var httpResponse = await _httpClient.GetAsync(_apiBaseUrl + "Customer");
        if (!httpResponse.IsSuccessStatusCode)
        {
            string error = httpResponse.StatusCode.ToString();
            throw new Exception(error);
        }
    
        var content = await httpResponse.Content.ReadAsStringAsync();
        var customerList = JsonSerializer.Deserialize<List<CustomerModel>>(content);
        return customerList;
    }

    public async Task <CustomerModel> GetCustomerById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateCustomer(CustomerModel customerModel)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateCustomer(CustomerModel customerModel)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCustomer(int id)
    {
        throw new NotImplementedException();
    }
}