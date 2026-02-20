namespace EasyClothing.Api.Http.StatusCodes
{
    public enum StatusCodesEnum
    {
        //200
        Ok = 200,
        Created = 201,
        NoContent = 204,

        //400
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,

        UnprocessableEntity = 422,
        InternalServerError = 500
    }
}
