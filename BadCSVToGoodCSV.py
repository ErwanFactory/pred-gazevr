import csv
import os

listfiles = os.listdir(os.getcwd() + '/data/')

def toIntOrFloat(x):
    if "." in x or "nan" in x.lower():
        return float(x)
    else:
        return int(x)

for curFile in listfiles:
    badCSV = open('data/' + curFile)
    print('Cleaning', curFile, '...')
    writer = csv.writer(open(curFile + "-clean.csv", "w+"), delimiter=',', quotechar='"', quoting=csv.QUOTE_NONNUMERIC)
    writer.writerow(['oculoTS','unityTS','currFrame','leftPosX','leftPosY','rightPosX','rightPosY','cam_pitch','cam_yaw','cam_roll','cam_x','cam_y','cam_z'])
    for line in badCSV:
        splitByVirgule = line.split(',')
        cleaned_line = list(map(lambda x: toIntOrFloat(x.split(':')[1]), splitByVirgule))
        writer.writerow(cleaned_line)
