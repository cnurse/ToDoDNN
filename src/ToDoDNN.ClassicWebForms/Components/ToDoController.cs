﻿// Copyright (c) Charles Nurse. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace ToDoDNN.ClassicWebForms.Components
{
    public class ToDoController
    {
        public int AddToDo(ToDo toDo)
        {
            return DataProvider.Instance().ExecuteScalar<int>("ToDoDNN_AddToDo", toDo.OwnerId, toDo.Name, toDo.Description, toDo.IsComplete);
        }

        public void DeleteToDo(ToDo toDo)
        {
            DataProvider.Instance().ExecuteNonQuery("ToDoDNN_DeleteToDo", toDo.ToDoId);
        }

        public ToDo GetToDo(int taskId)
        {
            return CBO.FillObject<ToDo>(DataProvider.Instance().ExecuteReader("ToDoDNN_GetToDo", taskId));
        }

        public IEnumerable<ToDo> GetToDos(int ownerId)
        {
            return CBO.FillCollection<ToDo>(DataProvider.Instance().ExecuteReader("ToDoDNN_GetToDos", ownerId));
        }

        public void UpdateToDo(ToDo toDo)
        {
            DataProvider.Instance().ExecuteNonQuery("ToDoDNN_UpdateToDo", toDo.ToDoId, toDo.Name, toDo.Description, toDo.IsComplete, toDo.IsDeleted);
        }
    }
}