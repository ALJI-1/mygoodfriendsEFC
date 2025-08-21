using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

using Configuration;
using Configuration.Options;

using Microsoft.Extensions.Options;
using AppWebApi.Models;
using Seido.Utilities.SeedGenerator;
using System.IO.Compression;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class EncryptionController : Controller
{
    readonly IConfiguration _configuration;
    readonly Encryptions _encryptions = null;
    readonly MySettingsOptions _msOptions;

    //GET: api/admin/key
    [HttpGet()]
    [ActionName("ReturnSettings")]
    [ProducesResponseType(200)]
    public IActionResult ReturnSettings()
    {
        try
        {

            return Ok(_msOptions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet()]
    [ActionName("EncryptedSettings")]
    [ProducesResponseType(200, Type = typeof(List<string>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public IActionResult EncryptedSettings()
    {
        try
        {
            var encrypted = _encryptions.AesEncryptToBase64<MySettingsOptions>(_msOptions);

            return Ok(encrypted);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //GET: api/admin/decryptedquote
    [HttpGet()]
    [ActionName("DecryptedSetting")]
    [ProducesResponseType(400, Type = typeof(string))]
    public IActionResult DecryptedSetting(string DecryptedSetting)
    {
        try
        {
            var decrypted = _encryptions.AesDecryptFromBase64<MySettingsOptions>(DecryptedSetting);

            return Ok(decrypted);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet()]
    [ActionName("EncryptPassword")]
    [ProducesResponseType(400, Type = typeof(string))]
    public IActionResult EncryptPassword(string pass)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(pass))
            {
                return BadRequest("lösenord är null eller tomt");
            }

            // Regex for strong password: min 8 chars, at least 1 uppercase, 1 lowercase, 1 digit, 1 special char
            var strongPasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(pass, strongPasswordPattern))
            {
                return BadRequest("Lösenordet är inte tillräckligt starkt. Minst 8 tecken, en versal, en gemen, en siffra och ett specialtecken krävs.");
            }

            return Ok(_encryptions.EncryptPasswordToBase64(pass));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    public EncryptionController(
            Encryptions encryptions,
            IConfiguration configuration,
            IOptions<MySettingsOptions> msOptions)
    {
        _encryptions = encryptions;
        _configuration = configuration;
        _msOptions = msOptions.Value;

    }

}
