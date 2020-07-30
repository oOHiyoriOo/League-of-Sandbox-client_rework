import requests
from requests.auth import HTTPBasicAuth
import urllib.parse
import json
import os

apiURL = "http://127.0.0.1"


if not os.path.isfile('token'):
    password = "123"
    # name = "Z%C3%A9roTw%C3%B3%235019"
    name = "ZéroTwó#5019"

    r = requests.post(apiURL+"/user.login",{'name':name,'pass':password})
    print(r.text)

    try:
        data = json.loads(r.text)

        print(data)
        token = data['token']

        with open("token","w",encoding='utf-8') as tokenFile:
            tokenFile.write(token)
    except Exception as err:
        print(err)
else:
    
    with open("token","r",encoding='utf-8') as tokenFile:
        token = tokenFile.read()
    print(token)

    # try create user!
    data = {}
    data['user'] = 210428907386699777

    rr = requests.post(apiURL+"/user.new",headers={'authorization':token},data=data)
    print(rr.text)


    # try get some money form bank top user
    data = {}
    data['from'] = 3406
    data['to'] = 210428907386699777
    data['type'] = "n"
    data['amount'] = 100
    rr = requests.post(apiURL+"/user.pay",headers={'authorization':token},data=data)
    print(rr.text)
