export const idlFactory = ({ IDL }) => {
  return IDL.Service({ 'storage' : IDL.Func([], [IDL.Principal], []) });
};
export const init = ({ IDL }) => { return []; };
