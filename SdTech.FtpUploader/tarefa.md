##Descri��o:

Preciso de um Execut�vel (FtpUpload.EXE) que receba par�metros de outro ERP e fa�a um upload/envio de uma arquivo especifico para um FTP. Como seria a Parte t�cnica:

- Teria que ser em Visual Studio 2015 (C#) e deve enviar o programa pronto e todas suas fontes que foi usado no mesmo.

- Deve funcionar em todas plataforma Windows Server e Windows Desktop.

- O ERP vai chamar este FtpUpload.EXE passando os par�metros:
P_Endere�o do FTP (Ex.: ftp.servidorteste.com.br)
P_Usu�rio Ex.: (joao_silva)
P_Senha (Ex.: Silva@123)
P_Enviar [Local com Nome onde esta o arquivo] (Ex.: S:\DROPBOX\BACKUP_SEXTA.RAR) a ser envia por para FTP

OBS: No Local l� no Servidor do FTP pode ser baixado no Raiz mesmo. Lembrando que sempre deve substituir o arquivo que estive no FTP sem perguntar.

Importante: Este programa (FtpUpload.EXE) quando acionado deve sempre ficar oculto, n�o deve aparece nenhum tela ou mensagem.

A linha exemplo de comando do ERP que vai chamar programa: FtpUpload.EXE ftp.servidorteste.com.br joao_silva Silva@123 S:\DROPBOX\BACKUP_SEXTA.RAR


Categoria: IT & Programa��o
Subcategoria: Desktop Applications
Qual � o alcance do projeto?: Bug ou altera��o pequena
Isso � um projeto ou uma posi��o de trabalho?: Um projeto
Tenho, atualmente: Eu tenho especifica��es
Experi�ncia nesse tipo de projeto: Sim (Eu j� gerenciei esse tipo de projeto)
Disponibilidade requerida: Conforme necess�rio
Plataformas exigidas: Windows