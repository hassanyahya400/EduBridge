﻿namespace EduBridge.API.Models.GenericResponse
{
    public class PagedResponse<T> : SuccessResponse
    {
        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public List<T>? Data { get; set; }
    }
}