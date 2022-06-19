  use UDPListener
  
  insert into IPAddresses
  values
  ('d80ca316-f10d-4293-94f8-3ef7e48950cf', '127.0.0.1')

  insert into Messages
  values
  (NEWID(), GETDATE(), 'test 1', 'd80ca316-f10d-4293-94f8-3ef7e48950cf'),  
  (NEWID(), GETDATE(), 'test 2', 'd80ca316-f10d-4293-94f8-3ef7e48950cf')