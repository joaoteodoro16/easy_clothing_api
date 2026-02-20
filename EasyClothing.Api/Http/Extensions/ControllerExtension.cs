using EasyClothing.Api.Http.Responses;
using EasyClothing.Api.Http.StatusCodes;
using EasyClothing.App.Common;
using Microsoft.AspNetCore.Mvc;




namespace EasyClothing.Api.Http.Extensions
{
    public static class ControllerExtensions
    {
        public static ActionResult<ApiResponse<T>> ToActionResult<T>(
            this ControllerBase controller,
            Result<T> result)
        {

            if (result.IsSuccess)
            {
                return controller.Ok(new ApiResponse<T>(
                    StatusCodesEnum.Ok,
                    result.Value,
                    true,
                    result.Message
                ));
            }

            var message = result.Error?.Message ?? "Ocorreu um erro inesperado.";

            return result.Error?.Code switch
            {
                ErrorCode.Unauthorized =>
                    controller.Unauthorized(Api<T>(
                        StatusCodesEnum.Unauthorized, message
                    )),

                ErrorCode.Conflict =>
                    controller.Conflict(Api<T>(
                        StatusCodesEnum.Conflict, message
                    )),

                ErrorCode.Validation =>
                    controller.UnprocessableEntity(Api<T>(
                        StatusCodesEnum.UnprocessableEntity, message
                    )),

                ErrorCode.NotFound =>
                    controller.NotFound(Api<T>(
                        StatusCodesEnum.NotFound, message
                    )),

                _ =>
                    controller.BadRequest(Api<T>(
                        StatusCodesEnum.BadRequest, message
                    ))
            };
        }

        private static ApiResponse<T> Api<T>(
            StatusCodesEnum status,
            string message)
        {
            return new ApiResponse<T>(
                status,
                default,
                false,
                message
            );
        }
    }
}
