##Descrição:

Preciso de um Executável (FtpUpload.EXE) que receba parâmetros de outro ERP e faça um upload/envio de uma arquivo especifico para um FTP. Como seria a Parte técnica:

- Teria que ser em Visual Studio 2015 (C#) e deve enviar o programa pronto e todas suas fontes que foi usado no mesmo.

- Deve funcionar em todas plataforma Windows Server e Windows Desktop.

- O ERP vai chamar este FtpUpload.EXE passando os parâmetros:
P_Endereço do FTP (Ex.: ftp.servidorteste.com.br)
P_Usuário Ex.: (joao_silva)
P_Senha (Ex.: Silva@123)
P_Enviar [Local com Nome onde esta o arquivo] (Ex.: S:\DROPBOX\BACKUP_SEXTA.RAR) a ser envia por para FTP

OBS: No Local lá no Servidor do FTP pode ser baixado no Raiz mesmo. Lembrando que sempre deve substituir o arquivo que estive no FTP sem perguntar.

Importante: Este programa (FtpUpload.EXE) quando acionado deve sempre ficar oculto, não deve aparece nenhum tela ou mensagem.

A linha exemplo de comando do ERP que vai chamar programa: FtpUpload.EXE ftp.servidorteste.com.br joao_silva Silva@123 S:\DROPBOX\BACKUP_SEXTA.RAR


Categoria: IT & Programação
Subcategoria: Desktop Applications
Qual é o alcance do projeto?: Bug ou alteração pequena
Isso é um projeto ou uma posição de trabalho?: Um projeto
Tenho, atualmente: Eu tenho especificações
Experiência nesse tipo de projeto: Sim (Eu já gerenciei esse tipo de projeto)
Disponibilidade requerida: Conforme necessário
Plataformas exigidas: Windows