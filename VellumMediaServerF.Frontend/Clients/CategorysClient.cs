using System;
using VellumMediaServerF.Frontend.Models;

namespace VellumMediaServerF.Frontend.Clients;


public class CategorysClient(HttpClient httpClient)
{

public async Task <Category[]> GetCategorysAsync() 
=> await httpClient.GetFromJsonAsync<Category[]>("categorys") ?? [];
}
