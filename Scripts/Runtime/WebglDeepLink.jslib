mergeInto(LibraryManager.library, {

  GetDeepLink: function () {
    var p = new URLSearchParams(window.location.search);
    instance.SendMessage('DeepLinker', 'RespondDeepLink', ((p.has('link'))? p.get('link') : 'null'));
  },
  CopyText: function (str) {
    navigator.clipboard.writeText(UTF8ToString(str));
    alert('Copied text!');
  },

});