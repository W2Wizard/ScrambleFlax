o = open("Output.txt", "a")

with open("Data.txt") as f:
    content = f.readlines()
    for string in content:
       o.write('"' + string + '",') 

f.close()
    