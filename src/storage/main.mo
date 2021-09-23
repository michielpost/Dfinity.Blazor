import Map "mo:base/HashMap";
import Text "mo:base/Text";
import Principal "mo:base/Principal";

shared(msg) actor class DataList() {

  let owner = msg.caller;

    type Name = Text;
    type Phone = Text;

  type Entry = {
    desc: Text;
    phone: Phone;
  };

  let phonebook = Map.HashMap<Name, Entry>(0, Text.equal, Text.hash);

  public shared(msg) func insert(name : Name, entry : Entry): async () {
    let userId = Principal.toText(msg.caller);
     phonebook.put(userId#name, entry);
  };

  public shared(msg) func lookup(name : Name) : async ?Entry {
    let userId = Principal.toText(msg.caller);
    phonebook.get(userId#name)
  };

  // Return the principal identifier of the caller of this method.
  public shared (msg) func whoami() : async Text {
    return Principal.toText(msg.caller);
  };


}

