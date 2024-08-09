

using Empresa.Endereco.Dominio.Entites;
using Newtonsoft.Json;

namespace Empresa.Endereco.Servico.ViaCep
{
    public class ViaCepService
    {
        //Função assincrona ira comunicar com o servidor e retornar um objeto Endereco
        public async Task<EnderecoEntity> ObterEnderecoPorCep(string cep)
        {
            //Abrindo uma comunicação de protocolo HTTP com outro servidor
            var httpClient = new HttpClient();

            //Executando uma requisição HTTP, passando o CEP de forma dinãnima utilizando formatação string
            var retornoRequisicao = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");   
            
            //Verificando se a requisição foi bem sucedida (status code 200)
            if(retornoRequisicao.IsSuccessStatusCode)
            {
                //se sucesso, retornar a informação pela API
                var objetoSerializado = await retornoRequisicao.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EnderecoEntity>(objetoSerializado);
            }
            return new EnderecoEntity();
        }

        public async Task ObterEnderecoPorCep(object cep)
        {
            throw new NotImplementedException();
        }
    }
}
