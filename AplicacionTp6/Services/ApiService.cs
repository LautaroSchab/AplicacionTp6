using AplicacionTp6.Models;
using System.Net.Http;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Text;

namespace AplicacionTp6.Services;

public class ApiService
{
    private static readonly string BASE_URL = "http://localhost:5094/api/";
    static HttpClient httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };

    public async Task<LoginResponseDto> ValidarLogin(string _username, string _contrasena)
    {
        string FINAL_URL = BASE_URL + "Usuario/ValidarCredencial";
        try
        {
            var content = new StringContent(
                JsonSerializer.Serialize(new
                {
                    username = _username,
                    contrasena = _contrasena,
                }),
                Encoding.UTF8, "application/json"
            );

            var result = await httpClient.PostAsync(FINAL_URL, content).ConfigureAwait(false);
            var jsonData = await result.Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                var responseObject = JsonSerializer.Deserialize<LoginResponseDto>(jsonData,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    });

                
                if (responseObject.IdUsuario == 0)
                {
                    throw new Exception("Credenciales incorrectas"); 
                }

                return responseObject;
            }
            else
            {
                throw new Exception("Resource Not Found");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }



}

