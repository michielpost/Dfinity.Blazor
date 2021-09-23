export const idlFactory = ({ IDL }) => {
  const Name = IDL.Text;
  const Phone = IDL.Text;
  const Entry = IDL.Record({ 'desc' : IDL.Text, 'phone' : Phone });
  const DataList = IDL.Service({
    'insert' : IDL.Func([Name, Entry], [], []),
    'lookup' : IDL.Func([Name], [IDL.Opt(Entry)], []),
    'whoami' : IDL.Func([], [IDL.Text], []),
  });
  return DataList;
};
export const init = ({ IDL }) => { return []; };
