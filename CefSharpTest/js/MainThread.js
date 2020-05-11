function temp()
{
	var result = new Object();
	result.uri = document.baseURI;
	result.content = document.getElementsByClassName("onboarding-ed__title js-onboarding-ed-balance-text")[0].textContent;
	result.intager = "123";
	result.Null = null;
	return result;
};
temp();