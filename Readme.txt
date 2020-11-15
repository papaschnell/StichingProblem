Problem:

- Make a request to a stiching service.
- Cancel the request before it is done.
- Make a new request before the canceled request is done (it keeps being process service side)
- Response to the new reqest is corrupted (mostly null but sometimes half filled)

Conclussion. Seems like that the ongoing canceled request is affecting the next incomming request.

Info. If not using stiching and just call the downstream service directly.
The problem is not there and it is completly stable around cancel requests
So seems like have to do with stiching.
