isBold = False
isType = False
readFileName = "table.txt"
writeFileName = "table.tex"
with open(readFileName) as rf:
	with open(writeFileName) as wf:
		while True:
			c = rf.read(1)
			if not c:
				print(End of file)
				break