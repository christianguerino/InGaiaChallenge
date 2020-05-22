import requests
import json

cidade = str(input('Informe a cidade: '))

headers = {'Content-Type': 'application/json',
           'Authorization': 'L23A567890'}

resp = requests.get('https://ingaiachallenge.azurewebsites.net/api/Music/city/Campinas/', headers=headers)
if resp.status_code == 200:
    data = resp.json()
    musicas = data['musicList']
    print('Em {} a temperatura agora é de: {}'.format(cidade, float(data['temperature'])))
    print('Segue a lista de músicas na categoria: {}'.format(data['musicCategory']))
    for musica in musicas:
        print('\t' + musica['musicName'])
else:
    print('Erro: ' + resp.status_code + ' ' + resp.text)

# mostrar todo o conteudo do json
#if resp.status_code == 200:
#    print(json.loads(resp.content.decode('utf-8')))
#