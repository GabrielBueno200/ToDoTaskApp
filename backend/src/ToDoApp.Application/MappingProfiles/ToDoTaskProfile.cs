using AutoMapper;
using ToDoApp.Application.Features.ToDoTasks.Commands.SaveToDoTask;
using ToDoApp.Application.Features.ToDoTasks.Commands.UpdateToDoTask;
using ToDoApp.Application.ViewModels;
using ToDoApp.Domain.Models;

namespace ToDoApp.Application.MappingProfiles;

public class ToDoTaskProfile : Profile
{
    public ToDoTaskProfile()
    {
        CreateMap<ToDoTask, ToDoTaskViewModel>().ReverseMap();
        CreateMap<SaveToDoTaskCommand, ToDoTask>();
        CreateMap<UpdateToDoTaskCommand, ToDoTask>();
    }
}