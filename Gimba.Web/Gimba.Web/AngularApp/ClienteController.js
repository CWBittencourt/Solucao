(function (app) {
    function ClienteController($scope, $http, clienteApiUrl) {

        $scope.clientes = [];
        $scope.endereco = new Object();
        $scope.emails = [];
        $scope.emailTemp = new Object();
        $scope.socios = [];
        $scope.socioTemp = new Object();
        $scope.telefones = [];
        $scope.telefone = new Object();


        $scope.deleta = function (id) {

            //procurar um contato com o id informado e deleta
            for (i in $scope.clientes) {
                if ($scope.clientes[i].IdCliente == id) {
                    $scope.clientes.splice(i, 1);
                    $scope.novocliente = {};
                }
            }
        }

        $scope.GetEndereco = function () {
            $http.get(clienteApiUrl + "?cep=" + $scope.ClienteDTO.Endereco.CEP).then(function (data) {
                $scope.endereco = data;
                console.log($scope.endereco);

                $('#tipologradouro').val($scope.endereco.data.TipoLogradouro);
                $('#logradouro').val($scope.endereco.data.Logradouro);
                $('#cep').val($scope.endereco.data.CEP);
                $('#bairro').val($scope.endereco.data.Bairro);
                $('#cidade').val($scope.endereco.data.Cidade);
                $('#uf').val($scope.endereco.data.UF);

                $('#numero').focus();


            });

        }

        $scope.salvaCliente = function () {



            if ((typeof $scope.ClienteDTO === "undefined") || (typeof $scope.ClienteDTO.Cliente === "undefined")) {
                alert("Informe o Cliente");
            }
            else if ((typeof $scope.ClienteDTO.Cliente.Nome === "undefined") || (typeof $scope.ClienteDTO.Cliente.CNPJ === "undefined")) {
                alert("Informe o Nome/CNPJ");
            } else if ($scope.validaCnpj($scope.ClienteDTO.Cliente.CNPJ) === false) {
                alert("CNPJ Inválido");
            }
            else if (($scope.ClienteDTO.Cliente.IdCliente == 0) || ($scope.ClienteDTO.Cliente.IdCliente == null)) {

                $scope.clientes.push($scope.ClienteDTO.Cliente);

                $scope.ClienteDTO.Endereco = new Object();
                $scope.ClienteDTO.Endereco.TipoLogradouro = $('#tipologradouro').val();
                $scope.ClienteDTO.Endereco.Logradouro = $('#logradouro').val();
                $scope.ClienteDTO.Endereco.CEP = $('#cep').val();
                $scope.ClienteDTO.Endereco.Bairro = $('#bairro').val();
                $scope.ClienteDTO.Endereco.Cidade = $('#cidade').val();
                $scope.ClienteDTO.Endereco.UF = $('#uf').val();
                $scope.ClienteDTO.Endereco.Numero = $('#numero').val();

                $scope.ClienteDTO.Cliente.emails = [];
                if ((typeof $scope.ClienteDTO.Endereco === "undefined") || (typeof $('#cep').val() === "undefined")) {
                    alert("Informe o Endereço");
                }
                else {
                    for (var i = 0; i < $scope.emails.length; i++) {
                        $scope.emailTemp = new Object();
                        $scope.emailTemp.IdEmail = 0;
                        $scope.emailTemp.IdCliente = $scope.ClienteDTO.Cliente.IdCliente;
                        $scope.emailTemp.Email = $scope.emails[i];
                        $scope.ClienteDTO.Cliente.emails.push($scope.emailTemp);
                    }

                    $scope.ClienteDTO.Cliente.telefones = [];

                    for (var i = 0; i < $scope.telefones.length; i++) {
                        $scope.telefone = new Object();
                        $scope.telefone.IdTelefone = 0;
                        $scope.telefone.IdCliente = $scope.ClienteDTO.Cliente.IdCliente;
                        $scope.telefone.IdTipoTelefone = $scope.telefones[i].IdTipoTelefone;
                        $scope.telefone.Numero = $scope.telefones[i].Numero;
                        $scope.telefone.DDD = $scope.telefones[i].DDD;

                        $scope.ClienteDTO.Cliente.telefones.push($scope.telefone);
                    }

                    $scope.ClienteDTO.Socios = [];
                    for (var i = 0; i < $scope.socios.length; i++) {
                        $scope.socioTemp = new Object();
                        $scope.socioTemp.Nome = $scope.socios[i].Nome;
                        $scope.socioTemp.CPF = $scope.socios[i].CPF;

                        $scope.ClienteDTO.Socios.push($scope.socioTemp);
                    }

                    $http.post(clienteApiUrl, $scope.ClienteDTO).then(function () {

                        //limpa o formulário
                        $scope.ClienteDTO.Cliente = {};
                        $scope.ClienteDTO.Endereco = {};
                        $scope.emails = {};
                        $scope.telefones = {};
                        $scope.socios = {};

                        //REDIRECIONA
                        $http.get(clienteApiUrl).then(function (data) {
                            $scope.clientes = data;
                        });
                    });
                }

            }
                //atualiza um contato existente
            else {
                for (i in $scope.clientes) {
                    if ($scope.clientes[i].IdCliente == $scope.Cliente.IdCliente) {
                        $scope.clientes[i] = $scope.Cliente;
                    }
                }
            }
        }

        $scope.setEmail = function () {
            if (typeof $scope.Email === "undefined") {
                alert("Informe o email");
            }
            else {
                if ($scope.emails.indexOf(angular.lowercase($scope.Email)) == -1) {
                    $scope.emails.push(angular.lowercase($scope.Email));
                    $scope.Email = '';
                    $scope.emailTemp = '';
                } else {
                    alert("Este item já foi adicionado");
                }
            }
        }

        $scope.setTelefone = function () {
            if (typeof $scope.Telefone === "undefined") { alert("Informe o telefone"); }
            else if (typeof $scope.Telefone.DDD === "undefined") {
                alert("Informe o DDD");
            }
            else if (typeof $scope.Telefone.Numero === "undefined") {
                alert("Informe o número do telefone");
            }
            else if (typeof $scope.Telefone.IdTipoTelefone === "undefined") {
                alert("Informe o tipo de telefone");
            }
            else {

                var telExiste = false;
                for (var i = 0; i < $scope.telefones.length; i++) {

                    if ($scope.telefones[i].DDD == $scope.Telefone.DDD && $scope.telefones[i].Numero == $scope.Telefone.Numero) {
                        telExiste = true;
                    }
                }

                if (telExiste == false) {
                    $scope.telefone.DDD = $scope.Telefone.DDD;
                    $scope.telefone.Numero = $scope.Telefone.Numero;
                    $scope.telefone.IdTipoTelefone = $scope.Telefone.IdTipoTelefone;
                    $scope.telefone.IdCliente = $scope.Telefone.IdCliente;
                    if ($scope.Telefone.IdTipoTelefone == 1) {
                        $scope.telefone.Tipo = 'Fixo';
                    }
                    else if ($scope.Telefone.IdTipoTelefone == 2) {
                        $scope.telefone.Tipo = 'Residencial';
                    }
                    else if ($scope.Telefone.IdTipoTelefone == 3) {
                        $scope.telefone.Tipo = 'Celular';
                    }

                    $scope.telefones.push($scope.telefone);

                    $scope.telefone = {};
                    $scope.Telefone = {};
                }
                else {
                    alert("Este telefone já foi adicionado");
                }
            }
        }

        $scope.setSocio = function () {


            var socioExiste = false;
            for (var i = 0; i < $scope.socios.length; i++) {

                if ($scope.socios[i].CPF == $scope.Socio.CPF) {
                    socioExiste = true;
                }
            }
            try {
                if (typeof $scope.Socio === "undefined") {
                    alert("Informe o Sócio");
                }
                else if (typeof $scope.Socio.Nome === "undefined") {
                    alert("Informe o nome do Sócio");
                }
                else {
                    if (socioExiste == false) {
                        if ($scope.validarCPF($scope.Socio.CPF)) {
                            $scope.socioTemp.Nome = $scope.Socio.Nome;
                            $scope.socioTemp.CPF = $scope.Socio.CPF;
                            $scope.socios.push($scope.socioTemp);
                            $scope.socioTemp = {};
                            $scope.Socio = {};
                        }
                        else {
                            alert("Atenção CPF Inválido");
                        }
                    }
                    else {
                        alert("Este Sócio já foi adicionado");
                    }
                }

            } catch (e) {
                alert("Informe o nome do Sócio");
            }


        }

        $scope.criar = function () {
            $http.get("/api/clientedto/#!/criar");
        }

        $scope.validarCPF = function (cpf) {
            var numeros, digitos, soma, i, resultado, digitos_iguais;
            digitos_iguais = 1;
            if (cpf.length < 11)
                return false;
            for (i = 0; i < cpf.length - 1; i++)
                if (cpf.charAt(i) != cpf.charAt(i + 1)) {
                    digitos_iguais = 0;
                    break;
                }
            if (!digitos_iguais) {
                numeros = cpf.substring(0, 9);
                digitos = cpf.substring(9);
                soma = 0;
                for (i = 10; i > 1; i--)
                    soma += numeros.charAt(10 - i) * i;
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != digitos.charAt(0))
                    return false;
                numeros = cpf.substring(0, 10);
                soma = 0;
                for (i = 11; i > 1; i--)
                    soma += numeros.charAt(11 - i) * i;
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != digitos.charAt(1))
                    return false;
                return true;
            }
            else
                return false;
        }

        $scope.validaCnpj = function (str) {
            str = str.replace('.', '');
            str = str.replace('.', '');
            str = str.replace('.', '');
            str = str.replace('-', '');
            str = str.replace('/', '');
            cnpj = str;
            var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais;
            digitos_iguais = 1;
            if (cnpj.length < 14 && cnpj.length < 15)
                return false;
            for (i = 0; i < cnpj.length - 1; i++)
                if (cnpj.charAt(i) != cnpj.charAt(i + 1)) {
                    digitos_iguais = 0;
                    break;
                }
            if (!digitos_iguais) {
                tamanho = cnpj.length - 2
                numeros = cnpj.substring(0, tamanho);
                digitos = cnpj.substring(tamanho);
                soma = 0;
                pos = tamanho - 7;
                for (i = tamanho; i >= 1; i--) {
                    soma += numeros.charAt(tamanho - i) * pos--;
                    if (pos < 2)
                        pos = 9;
                }
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != digitos.charAt(0))
                    return false;
                tamanho = tamanho + 1;
                numeros = cnpj.substring(0, tamanho);
                soma = 0;
                pos = tamanho - 7;
                for (i = tamanho; i >= 1; i--) {
                    soma += numeros.charAt(tamanho - i) * pos--;
                    if (pos < 2)
                        pos = 9;
                }
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != digitos.charAt(1))
                    return false;
                return true;
            }
            else
                return false;
        }


        $scope.deletar = function () {
            return $http.delete(clienteApiUrl + $scope('#idcliente').val());
        };

    }

    app.controller("ClienteController", ClienteController)

}(angular.module("clientedto")));


