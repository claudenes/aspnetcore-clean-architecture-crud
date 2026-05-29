namespace Colorado.Application.Services
{
    public class ValidaErroService
    {
        public static ResultService DtoNulo()
        {
            return ResultService.Fail("400 - Bad Request - Objeto deve ser informado!");
        }

        public static ResultService RegistroExistente()
        {
            return ResultService.Fail("500 - Registro já existe na base de Dados!");
        }
        public static ResultService RegistroIdsNulo()
        {
            return ResultService.Fail("400 - Bad Request - Objeto SistemaId ou SubSistemaId devem ser informado!");
        }
        public static ResultService RegistroIdsNuloEquipamento()
        {
            return ResultService.Fail("400 - Bad Request - Objeto FuncaoId ou SubFuncaoId devem ser informado!");
        }

        //public static ResultService CampoDtoInvalido(FluentValidation.Results.ValidationResult Objeto)
        //{
        //    return ResultService.RequestError($"400 - Bad Request - Problemas com a validação de campos, {Objeto}", Objeto);
        //}

        public static ResultService RegistroIncluido(object Objeto)
        {
            return new ResultService { Message = "200 - Ok - Registro criado com sucesso", IsSuccess = true, Registro = Objeto };
        }
        public static ResultService RegistroEquipamentoIncluido(object Objeto)
        {
            return new ResultService { Message = "Função automática. necessário rever o mapa de condições!", IsSuccess = true, Registro = Objeto };
        }
        public static ResultService RegistroAtualizado(object Objeto)
        {
            return new ResultService { Message = "200 - Ok - Registro atualizado com sucesso", IsSuccess = true, Registro = Objeto };
        }

        public static ResultService RegistroPaiInvalido()
        {
            return ResultService.Fail("409 - Registro pai não registrado na base de Dados!");
        }

        public static ResultService RelacionamentoInvalido()
        {
            return ResultService.Fail("400 - Bad Resquest - Relacionamento inválido entre registros, atualização não será realizada!");
        }

        public static ResultService RegistroInexistente()
        {
            return ResultService.Fail("500 - Bad Resquest - Registro para atualização não existe na base de Dados!");
        }
        public static ResultService ErroGravacao()
        {
            return ResultService.Fail("500 - Erro ao gravar dados!");
        }
    }
}
