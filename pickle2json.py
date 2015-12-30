import json, pickle

with open("/home/tahoe_user/.gatherer/stats.pickle", "rb") as fpick:
    x = pickle.load(fpick)
    data = {}
    keylist = x.keys()
    data['servers'] = []
    for key in keylist:
      q = {}

      q["nickname"] = x[key]["nickname"]
      q["timestamp"] = x[key]["timestamp"]
      q["data"] = {}
      q["data"]["stats"] = {}
      q["data"]["counters"] = {}
      q["data"]["stats"] = x[key]["stats"]["stats"]
      q["data"]["counters"] = x[key]["stats"]["counters"]
      data["servers"].append(q)

    print json.dumps(data, indent=4, sort_keys=True)
