﻿using APIServices;
using LocadoraImoveisModels.Models;
using LocadoraImoveisModels.Models.Attributes;
using LocadoraImoveisModels.Models.DataBase;
using LocadoraImoveisModels.Models.Enums;
using LocadoraImoveisModels.Models.Exceptions;
using LocadoraImoveisModels.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LocadoraImoveisAPI.Controllers
{
  [Authorize]
  [Route("User")]
  public class UserController : CustomizedController
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }


    [HttpDelete]
    [Route("RemoveAdmin/{idUser}")]
    [RequireAdmin]
    public IActionResult RemoveAdmin(int idUser)
    {
      try
      {
        ResultUser? users = _userService.RemoveAdmin(idUser);
        return Ok(new Result(ResultType.Success.GetDescription(), users));
      }
      catch (ValidationErroException ex)
      {
        return Ok(new ValidationErrorResult(ex.Errors));
      }
      catch (Exception ex)
      {
        return Ok(new Result(ResultType.Error.GetDescription(), null));
      }
    }

    [HttpPost]
    [Route("MakeAdmin/{idUser}")]
    [RequireAdmin]
    public IActionResult MakeAdmin(int idUser)
    {
      try
      {
        ResultUser? users = _userService.MakeAdmin(idUser);
        return Ok(new Result(ResultType.Success.GetDescription(), users));
      }
      catch (ValidationErroException ex)
      {
        return Ok(new ValidationErrorResult(ex.Errors));
      }
      catch (Exception ex)
      {
        return Ok(new Result(ResultType.Error.GetDescription(), null));
      }
    }


    [HttpGet]
    [Route("Get/{idUser}")]
    [RequireAdmin]
    public IActionResult GetUser(int idUser)
    {
      try
      {
        ResultUser? users = _userService.GetUser(idUser);
        return Ok(new Result(ResultType.Success.GetDescription(), users));
      }
      catch (ValidationErroException ex)
      {
        return Ok(new ValidationErrorResult(ex.Errors));
      }
      catch (Exception ex)
      {
        return Ok(new Result(ResultType.Error.GetDescription(), "Ocorreu um erro, tente novamente mais tarde!"));
      }
    }

    [HttpGet]
    [Route("Get")]
    [RequireAdmin]
    public IActionResult GetUsers()
    {
      try
      {
        List<ResultUser> users = _userService.GetUsers();
        return Ok(new Result(ResultType.Success.GetDescription(), users));
      }
      catch (ValidationErroException ex)
      {
        return Ok(new ValidationErrorResult(ex.Errors));
      }
      catch (Exception ex)
      {
        return Ok(new Result(ResultType.Error.GetDescription(), "Ocorreu um erro, tente novamente mais tarde!"));
      }
    }

    [HttpPost]
    [Route("Register")]
    [AllowAnonymous]
    public IActionResult RegisterUser([FromBody]RegisterUser user)
    {
      try
      {
        if (ModelState.IsValid)
        {
          ResultUser result = _userService.CreateUser(user);
          return Ok(new Result(ResultType.Success.GetDescription(), result));
        }
        List<ValidationResult> validationErrors = ModelState
          .Where(x => x.Value!.Errors.Any())
          .Select(x => new ValidationResult(x.Value!.Errors.First().ErrorMessage, new[] { x.Key })).ToList();
        return Ok(new ValidationErrorResult(validationErrors));
      } 
      catch (ValidationErroException ex)
      {
        return Ok(new ValidationErrorResult(ex.Errors));
      }
      catch (Exception ex)
      {
        return Ok(new Result(ResultType.Error.ToString(), "Ocorreu um erro inesperado, tente novamente mais tarde!"));
      }
    }


    [HttpPost]
    [Route("Login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginUser user)
    {
      try
      {
        if (ModelState.IsValid)
        {
          LoggedUser? result = _userService.AuthenticateUser(user);
          if (result != null)
            return Ok(new Result(ResultType.Success.GetDescription(), result));
          else
            return Ok(new Result(ResultType.Error.GetDescription(), "Usuário ou Senha incorreto(s)!"));
        }
        List<ValidationResult> validationErrors  = ModelState
          .Where(x => x.Value!.Errors.Any())
          .Select(x => new ValidationResult(x.Value!.Errors.First().ErrorMessage, new[] { x.Key })).ToList();
        return Ok(new ValidationErrorResult(validationErrors));
      }
      catch (ValidationErroException ex)
      {
        return Ok(new ValidationErrorResult(ex.Errors));
      }
      catch (Exception ex)
      {
        return Ok(new Result(ResultType.Error.ToString(), "Ocorreu um erro inesperado, tente novamente mais tarde!"));
      }
    }
  }
}