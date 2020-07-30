use admin
db.createUser({user: "root",pwd:"toor",roles:[{role:"userAdminAnyDatabase",db:"admin"},"readWriteAnyDatabase"]})