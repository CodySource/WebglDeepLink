mergeInto(LibraryManager.library, {

  GetDeepLink: function () {
    var p = new URLSearchParams(window.location.search);
    instance.SendMessage('DeepLinker', 'RespondDeepLink', ((p.has('link'))? p.get('link') : 'null'));
  },
  CopyText: function (str) {
    navigator.permissions.query({ name: 'write-on-clipboard' }).then((result) => {
      if (result.state == 'granted' || result.state == 'prompt')
      {
        navigator.clipboard.writeText(UTF8ToString(str));
        alert('Coppied text!');
      }
    });
  },

});