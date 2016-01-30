# WebApi-TokenBasedAuthentication
Mvc Web Api Token Based Authentication

# I have created the account controller which will return the token first time login.
* The url will be http://localhost:6469/api/account/login?email=mukeshsalaria01@gmail.com&password=password
* Then the login method will return the token, next time add that token with other calls. But before that don't forgot to add RESTAuthorize attribute. I just added that attribute to values controller. The next call will be like below :-
* http://localhost:6469/api/values?token=WldkSUt4VU83UnpEU29IcmxPbldlSEp4RXhkMmFET2NHTm1uWlMvS1pvMD06bXVrZXNoc2FsYXJpYTAxQGdtYWlsLmNvbTo2MzU4OTc1MjI4MTEwNTI3ODk=
* The token you can replace with the your token return by the login method.

